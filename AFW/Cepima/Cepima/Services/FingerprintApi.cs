// ============================================================
// FingerprintApi.cs
// CEPIMA - API R307
// ============================================================

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.Services
{
    public class FingerprintApi
    {
        private HttpListener listener;
        private bool running;

        private readonly Database db =
            new Database();

        // ========================================================
        // CONFIGURATION ESP32
        // ========================================================

        private const string ESP32_IP =
            "192.168.200.50";

        private const int ESP32_PORT =
            8080;

        private const string ESP32_BASE_URL =
            "http://192.168.200.50:8080";


        // ========================================================
        // START
        // ========================================================

        public void Start(int port)
        {
            if (running)
                return;

            try
            {
                listener =
                    new HttpListener();

                listener.Prefixes.Add(
                    "http://+:" +
                    port +
                    "/");

                listener.Start();

                running = true;

                Task.Factory.StartNew(
                    ListenLoop,
                    TaskCreationOptions.LongRunning);

                Console.WriteLine(
                    "Fingerprint API démarrée sur le port " +
                    port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de démarrer Fingerprint API.\n\n" +
                    ex.Message,
                    "CEPIMA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ========================================================
        // STOP
        // ========================================================

        public void Stop()
        {
            running = false;

            if (listener != null)
            {
                try
                {
                    listener.Stop();
                    listener.Close();
                }
                catch
                {
                }
            }
        }


        // ========================================================
        // LISTEN
        // ========================================================

        private void ListenLoop()
        {
            while (running)
            {
                try
                {
                    HttpListenerContext context =
                        listener.GetContext();

                    Task.Factory.StartNew(
                        delegate
                        {
                            ProcessRequest(context);
                        });
                }
                catch
                {
                    if (!running)
                        break;
                }
            }
        }


        // ========================================================
        // ROUTES
        // ========================================================

        private void ProcessRequest(
            HttpListenerContext context)
        {
            try
            {
                string method =
                    context.Request.HttpMethod;

                string path =
                    context.Request.Url.AbsolutePath
                    .TrimEnd('/');

                // ------------------------------------------------
                // PRESENCE
                // ------------------------------------------------

                if (
                    method == "POST" &&
                    path ==
                    "/api/fingerprint/attendance")
                {
                    ProcessAttendance(context);
                    return;
                }

                // ------------------------------------------------
                // EMPREINTE INCONNUE
                // ------------------------------------------------

                if (
                    method == "POST" &&
                    path ==
                    "/api/fingerprint/scan")
                {
                    ProcessScan(context);
                    return;
                }

                // ------------------------------------------------
                // ENDPOINT INCONNU
                // ------------------------------------------------

                SendResponse(
                    context,
                    404,
                    "{\"success\":false," +
                    "\"message\":\"Endpoint not found\"}");
            }
            catch (Exception ex)
            {
                try
                {
                    SendResponse(
                        context,
                        500,
                        "{\"success\":false," +
                        "\"message\":\"" +
                        EscapeJson(ex.Message) +
                        "\"}");
                }
                catch
                {
                }
            }
        }


        // ========================================================
        // ATTENDANCE
        // ========================================================

        private void ProcessAttendance(
            HttpListenerContext context)
        {
            try
            {
                string body =
                    ReadBody(context);

                int fingerprintId =
                    GetIntJson(
                        body,
                        "fingerprint_id");

                int score =
                    GetIntJson(
                        body,
                        "score");

                if (fingerprintId <= 0)
                {
                    SendResponse(
                        context,
                        404,
                        "{\"success\":false," +
                        "\"message\":\"Agent non reconnu\"}");

                    return;
                }

                RegisterAttendance(
                    context,
                    fingerprintId,
                    score);
            }
            catch (Exception ex)
            {
                SendResponse(
                    context,
                    500,
                    "{\"success\":false," +
                    "\"message\":\"" +
                    EscapeJson(ex.Message) +
                    "\"}");
            }
        }


        // ========================================================
        // SCAN INCONNU
        // ========================================================

        private void ProcessScan(
            HttpListenerContext context)
        {
            try
            {
                string body =
                    ReadBody(context);

                int fingerprintId =
                    GetIntJson(
                        body,
                        "fingerprint_id");

                int score =
                    GetIntJson(
                        body,
                        "score");

                // ------------------------------------------------
                // INCONNU
                // ------------------------------------------------

                if (fingerprintId <= 0)
                {
                    SendResponse(
                        context,
                        404,
                        "{\"success\":false," +
                        "\"message\":\"Agent non reconnu\"}");

                    Task.Factory.StartNew(
                        ShowUnknownAgentDialog);

                    return;
                }

                // ------------------------------------------------
                // RECONNU
                // ------------------------------------------------

                RegisterAttendance(
                    context,
                    fingerprintId,
                    score);
            }
            catch (Exception ex)
            {
                SendResponse(
                    context,
                    500,
                    "{\"success\":false," +
                    "\"message\":\"" +
                    EscapeJson(ex.Message) +
                    "\"}");
            }
        }


        // ========================================================
        // AGENT INCONNU
        // ========================================================

        private void ShowUnknownAgentDialog()
        {
            try
            {
                DialogResult result =
                    MessageBox.Show(
                        "Agent non reconnu.\n\n" +
                        "Voulez-vous l'ajouter ?",
                        "CEPIMA - R307",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (
                    result ==
                    DialogResult.Yes)
                {
                    OpenAddPersonnelForm();
                }
            }
            catch
            {

            }
        }


        // ========================================================
        // OUVRIR FORMULAIRE PERSONNEL
        // ========================================================

        private void OpenAddPersonnelForm()
        {
            try
            {
                int fingerprintId =
                    GetNextFingerprintId();

                Action action =
                    delegate
                    {
                        using (
                            MesForms.Personnel.Ajout_personnel form =
                            new MesForms.Personnel.Ajout_personnel())
                        {
                            form.FingerprintId =
                                fingerprintId;

                            form.ShowDialog();
                        }
                    };

                if (
                    Application.OpenForms.Count == 0)
                    return;

                Form mainForm =
                    Application.OpenForms[0];

                if (mainForm.InvokeRequired)
                {
                    mainForm.BeginInvoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception ex)
            {
                ShowError(
                    "Erreur ouverture formulaire :\n\n" +
                    ex.Message);
            }
        }


        // ========================================================
        // PROCHAIN FINGERPRINT ID
        // ========================================================

        private int GetNextFingerprintId()
        {
            using (
                MySqlConnection con =
                db.GetConnection())
            {
                con.Open();

                string sql =
                    "SELECT COALESCE(" +
                    "MAX(fingerprint_id),0) + 1 " +
                    "FROM personnels";

                using (
                    MySqlCommand cmd =
                    new MySqlCommand(
                        sql,
                        con))
                {
                    return Convert.ToInt32(
                        cmd.ExecuteScalar());
                }
            }
        }


        // ========================================================
        // DEMARRER ENROLEMENT ESP32
        // ========================================================

        public static async Task<bool>
            StartFingerprintEnrollment(
                int fingerprintId)
        {
            try
            {
                string url =
                    ESP32_BASE_URL +
                    "/api/fingerprint/enroll";

                string json =
                    "{\"fingerprint_id\":" +
                    fingerprintId +
                    "}";

                Console.WriteLine();
                Console.WriteLine(
                    "================================");
                Console.WriteLine(
                    "ENVOI ENROLEMENT ESP32");
                Console.WriteLine(
                    "================================");

                Console.WriteLine(
                    "URL : " +
                    url);

                Console.WriteLine(
                    "JSON : " +
                    json);

                HttpWebRequest request =
                    (HttpWebRequest)
                    WebRequest.Create(url);

                request.Method =
                    "POST";

                request.ContentType =
                    "application/json";

                request.Timeout =
                    5000;

                request.ReadWriteTimeout =
                    5000;

                byte[] data =
                    Encoding.UTF8.GetBytes(
                        json);

                request.ContentLength =
                    data.Length;

                using (
                    Stream stream =
                    await request
                    .GetRequestStreamAsync())
                {
                    await stream.WriteAsync(
                        data,
                        0,
                        data.Length);
                }

                using (
                    HttpWebResponse response =
                    (HttpWebResponse)
                    await request
                    .GetResponseAsync())
                {
                    string responseBody =
                        ReadHttpResponse(
                            response);

                    Console.WriteLine(
                        "HTTP ESP32 : " +
                        (int)
                        response.StatusCode);

                    Console.WriteLine(
                        "ESP32 : " +
                        responseBody);

                    return
                        response.StatusCode ==
                        HttpStatusCode.OK ||
                        response.StatusCode ==
                        HttpStatusCode.Accepted;
                }
            }
            catch (WebException ex)
            {
                string message =
                    ex.Message;

                if (ex.Response != null)
                {
                    try
                    {
                        using (
                            HttpWebResponse response =
                            (HttpWebResponse)
                            ex.Response)
                        {
                            message +=
                                "\nHTTP : " +
                                (int)
                                response.StatusCode;

                            message +=
                                "\n" +
                                ReadHttpResponse(
                                    response);
                        }
                    }
                    catch
                    {
                    }
                }

                Console.WriteLine(
                    "Erreur ESP32 : " +
                    message);

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Erreur envoi ESP32 : " +
                    ex.Message);

                return false;
            }
        }


        // ========================================================
        // ATTENDRE RESULTAT ENROLEMENT
        // ========================================================
        //
        // IMPORTANT :
        // On ne se contente plus de rechercher une chaîne JSON
        // exacte.
        //
        // On extrait réellement enroll_status.
        //
        // success -> terminé
        // error   -> terminé avec erreur
        //
        // ========================================================

        public static async Task<string>
            WaitEnrollmentResult(
                int fingerprintId)
        {
            string url =
                ESP32_BASE_URL +
                "/api/fingerprint/status";

            Console.WriteLine();
            Console.WriteLine(
                "================================");
            Console.WriteLine(
                "ATTENTE RESULTAT ENROLEMENT");
            Console.WriteLine(
                "================================");

            Console.WriteLine(
                "Fingerprint ID : " +
                fingerprintId);

            Console.WriteLine(
                "URL : " +
                url);

            // 5 minutes maximum
            for (int i = 0; i < 300; i++)
            {
                try
                {
                    HttpWebRequest request =
                        (HttpWebRequest)
                        WebRequest.Create(url);

                    request.Method =
                        "GET";

                    request.Timeout =
                        3000;

                    request.ReadWriteTimeout =
                        3000;

                    using (
                        HttpWebResponse response =
                        (HttpWebResponse)
                        await request
                        .GetResponseAsync())
                    {
                        string body =
                            ReadHttpResponse(
                                response);

                        Console.WriteLine(
                            "STATUS ESP32 : " +
                            body);

                        if (
                            string.IsNullOrWhiteSpace(
                                body))
                        {
                            Console.WriteLine(
                                "STATUS ESP32 VIDE");
                        }
                        else
                        {
                            string status =
                                GetJsonString(
                                    body,
                                    "enroll_status");

                            int returnedId =
                                GetIntJson(
                                    body,
                                    "fingerprint_id");

                            string message =
                                GetJsonString(
                                    body,
                                    "message");

                            Console.WriteLine(
                                "Etat enrôlement : " +
                                status);

                            Console.WriteLine(
                                "ID ESP32 : " +
                                returnedId);

                            Console.WriteLine(
                                "Message ESP32 : " +
                                message);

                            // --------------------------------
                            // SUCCES
                            // --------------------------------

                            if (
                                status.Equals(
                                    "success",
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                if (
                                    returnedId == 0 ||
                                    returnedId ==
                                    fingerprintId)
                                {
                                    Console.WriteLine(
                                        "ENROLEMENT TERMINE AVEC SUCCES");

                                    return "success";
                                }
                            }

                            // --------------------------------
                            // ERREUR
                            // --------------------------------

                            if (
                                status.Equals(
                                    "error",
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(
                                    "ERREUR ENROLEMENT : " +
                                    message);

                                return "error";
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine(
                        "Erreur HTTP status : " +
                        ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "Erreur status : " +
                        ex.Message);
                }

                await Task.Delay(1000);
            }

            Console.WriteLine(
                "TIMEOUT ENROLEMENT");

            return "timeout";
        }


        // ========================================================
        // EXTRAIRE STRING JSON SIMPLE
        // ========================================================

        private static string GetJsonString(
            string json,
            string property)
        {
            if (
                string.IsNullOrWhiteSpace(
                    json))
                return "";

            string search =
                "\"" +
                property +
                "\"";

            int index =
                json.IndexOf(
                    search,
                    StringComparison.OrdinalIgnoreCase);

            if (index < 0)
                return "";

            index =
                json.IndexOf(
                    ":",
                    index);

            if (index < 0)
                return "";

            index++;

            while (
                index < json.Length &&
                Char.IsWhiteSpace(
                    json[index]))
            {
                index++;
            }

            if (
                index >= json.Length ||
                json[index] != '"')
            {
                return "";
            }

            index++;

            StringBuilder value =
                new StringBuilder();

            while (index < json.Length)
            {
                char c =
                    json[index];

                if (c == '"')
                    break;

                if (
                    c == '\\' &&
                    index + 1 <
                    json.Length)
                {
                    index++;

                    char next =
                        json[index];

                    if (next == 'n')
                        value.Append('\n');
                    else if (next == 'r')
                        value.Append('\r');
                    else if (next == '"')
                        value.Append('"');
                    else if (next == '\\')
                        value.Append('\\');
                    else
                        value.Append(next);
                }
                else
                {
                    value.Append(c);
                }

                index++;
            }

            return value.ToString();
        }


        // ========================================================
        // HTTP RESPONSE -> STRING
        // ========================================================

        private static string
            ReadHttpResponse(
                HttpWebResponse response)
        {
            if (response == null)
                return "";

            using (
                Stream stream =
                response.GetResponseStream())
            {
                if (stream == null)
                    return "";

                using (
                    StreamReader reader =
                    new StreamReader(
                        stream,
                        Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        // ========================================================
        // PRESENCE
        // ========================================================

        private void RegisterAttendance(
            HttpListenerContext context,
            int fingerprintId,
            int score)
        {
            using (
                MySqlConnection con =
                db.GetConnection())
            {
                con.Open();

                int personnelId = 0;

                string nom = "";
                string postNom = "";
                string prenom = "";

                // ------------------------------------------------
                // RECHERCHER AGENT
                // ------------------------------------------------

                string sql =
                    "SELECT " +
                    "id_personnel," +
                    "nom," +
                    "post_nom," +
                    "prenom " +
                    "FROM personnels " +
                    "WHERE fingerprint_id = @fingerprint_id " +
                    "AND actif = 1 " +
                    "LIMIT 1";

                using (
                    MySqlCommand cmd =
                    new MySqlCommand(
                        sql,
                        con))
                {
                    cmd.Parameters.AddWithValue(
                        "@fingerprint_id",
                        fingerprintId);

                    using (
                        MySqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            SendResponse(
                                context,
                                404,
                                "{\"success\":false," +
                                "\"message\":\"Agent non trouvé\"}");

                            return;
                        }

                        personnelId =
                            Convert.ToInt32(
                                reader[
                                    "id_personnel"]);

                        nom =
                            reader["nom"]
                            .ToString();

                        postNom =
                            reader["post_nom"]
                            .ToString();

                        prenom =
                            reader["prenom"]
                            .ToString();
                    }
                }


                // ------------------------------------------------
                // PRESENCE DU JOUR
                // ------------------------------------------------

                bool exists = false;

                string heureEntree = "";
                string heureSortie = "";

                string findSql =
                    "SELECT " +
                    "heure_entree," +
                    "heure_sortie " +
                    "FROM presences " +
                    "WHERE id_personnel = @id_personnel " +
                    "AND date_presence = CURDATE() " +
                    "LIMIT 1";

                using (
                    MySqlCommand cmd =
                    new MySqlCommand(
                        findSql,
                        con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id_personnel",
                        personnelId);

                    using (
                        MySqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exists = true;

                            if (
                                reader[
                                    "heure_entree"] !=
                                DBNull.Value)
                            {
                                heureEntree =
                                    reader[
                                        "heure_entree"]
                                    .ToString();
                            }

                            if (
                                reader[
                                    "heure_sortie"] !=
                                DBNull.Value)
                            {
                                heureSortie =
                                    reader[
                                        "heure_sortie"]
                                    .ToString();
                            }
                        }
                    }
                }


                // ------------------------------------------------
                // ENTREE
                // ------------------------------------------------

                if (!exists)
                {
                    string insertSql =
                        "INSERT INTO presences " +
                        "(" +
                        "id_personnel," +
                        "date_presence," +
                        "heure_entree," +
                        "statut" +
                        ") VALUES (" +
                        "@id_personnel," +
                        "CURDATE()," +
                        "CURTIME()," +
                        "'Présent'" +
                        ")";

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            insertSql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            personnelId);

                        cmd.ExecuteNonQuery();
                    }

                    heureEntree =
                        DateTime.Now
                        .ToString(
                            "HH:mm:ss");

                    SendResponse(
                        context,
                        200,
                        "{\"success\":true," +
                        "\"message\":\"Présence enregistrée\"," +
                        "\"fingerprint_id\":" +
                        fingerprintId +
                        ",\"score\":" +
                        score +
                        "}");

                    ShowAttendanceMessage(
                        nom,
                        postNom,
                        prenom,
                        "Entrée",
                        heureEntree,
                        score);

                    return;
                }


                // ------------------------------------------------
                // SORTIE
                // ------------------------------------------------

                if (
                    string.IsNullOrWhiteSpace(
                        heureSortie))
                {
                    string updateSql =
                        "UPDATE presences " +
                        "SET heure_sortie = CURTIME() " +
                        "WHERE id_personnel = @id_personnel " +
                        "AND date_presence = CURDATE()";

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            updateSql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            personnelId);

                        cmd.ExecuteNonQuery();
                    }

                    heureSortie =
                        DateTime.Now
                        .ToString(
                            "HH:mm:ss");

                    SendResponse(
                        context,
                        200,
                        "{\"success\":true," +
                        "\"message\":\"Sortie enregistrée\"," +
                        "\"fingerprint_id\":" +
                        fingerprintId +
                        ",\"score\":" +
                        score +
                        "}");

                    ShowAttendanceMessage(
                        nom,
                        postNom,
                        prenom,
                        "Sortie",
                        heureSortie,
                        score);

                    return;
                }


                // ------------------------------------------------
                // DEJA COMPLET
                // ------------------------------------------------

                SendResponse(
                    context,
                    200,
                    "{\"success\":true," +
                    "\"message\":\"Présence déjà complète\"," +
                    "\"fingerprint_id\":" +
                    fingerprintId +
                    ",\"score\":" +
                    score +
                    "}");
            }
        }


        // ========================================================
        // MESSAGE PRESENCE
        // ========================================================

        private void ShowAttendanceMessage(
            string nom,
            string postNom,
            string prenom,
            string type,
            string heure,
            int score)
        {
            Action action =
                delegate
                {
                    MessageBox.Show(
                        "Agent : " +
                        nom +
                        " " +
                        postNom +
                        " " +
                        prenom +
                        "\n\n" +
                        type +
                        " : " +
                        heure +
                        "\n" +
                        "Score : " +
                        score,
                        "CEPIMA - Présence",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                };

            try
            {
                if (
                    Application.OpenForms.Count >
                    0)
                {
                    Form form =
                        Application.OpenForms[0];

                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke(action);
                    }
                    else
                    {
                        action();
                    }
                }
            }
            catch
            {
            }
        }


        // ========================================================
        // READ BODY
        // ========================================================

        private string ReadBody(
            HttpListenerContext context)
        {
            using (
                StreamReader reader =
                new StreamReader(
                    context.Request.InputStream,
                    context.Request.ContentEncoding))
            {
                return reader.ReadToEnd();
            }
        }


        // ========================================================
        // JSON INT
        // ========================================================

        private static int GetIntJson(
            string json,
            string property)
        {
            if (
                string.IsNullOrEmpty(
                    json))
                return 0;

            string search =
                "\"" +
                property +
                "\"";

            int index =
                json.IndexOf(
                    search,
                    StringComparison.OrdinalIgnoreCase);

            if (index < 0)
                return 0;

            index =
                json.IndexOf(
                    ":",
                    index);

            if (index < 0)
                return 0;

            index++;

            while (
                index < json.Length &&
                Char.IsWhiteSpace(
                    json[index]))
            {
                index++;
            }

            StringBuilder value =
                new StringBuilder();

            while (index < json.Length)
            {
                char c =
                    json[index];

                if (
                    c == ',' ||
                    c == '}' ||
                    Char.IsWhiteSpace(c))
                {
                    break;
                }

                value.Append(c);
                index++;
            }

            int result;

            if (
                Int32.TryParse(
                    value.ToString(),
                    out result))
            {
                return result;
            }

            return 0;
        }


        // ========================================================
        // RESPONSE
        // ========================================================

        private void SendResponse(
            HttpListenerContext context,
            int statusCode,
            string body)
        {
            byte[] data =
                Encoding.UTF8.GetBytes(
                    body);

            context.Response.StatusCode =
                statusCode;

            context.Response.ContentType =
                "application/json; charset=utf-8";

            context.Response.ContentLength64 =
                data.Length;

            context.Response.KeepAlive =
                false;

            using (
                Stream output =
                context.Response.OutputStream)
            {
                output.Write(
                    data,
                    0,
                    data.Length);
            }
        }


        // ========================================================
        // MESSAGE ERREUR
        // ========================================================

        private void ShowError(
            string message)
        {
            Action action =
                delegate
                {
                    MessageBox.Show(
                        message,
                        "CEPIMA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                };

            try
            {
                if (
                    Application.OpenForms.Count >
                    0)
                {
                    Form form =
                        Application.OpenForms[0];

                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke(action);
                    }
                    else
                    {
                        action();
                    }
                }
            }
            catch
            {
            }
        }


        // ========================================================
        // ESCAPE JSON
        // ========================================================

        private string EscapeJson(
            string value)
        {
            if (value == null)
                return "";

            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }
    }
}