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
using Cepima.MesUserCases.Personnels;
using Cepima.MesForms.Personnel;

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

        private static readonly string ESP32_IP =
            EnvConfig.Get(
                "ESP32_IP",
                "192.168.200.50");

        private static readonly int ESP32_PORT =
            EnvConfig.GetInt(
                "ESP32_PORT",
                8080);

        private static readonly string ESP32_BASE_URL =
            "http://" +
            ESP32_IP +
            ":" +
            ESP32_PORT;

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
                //MessageBox.Show(
                //    "Impossible de démarrer Fingerprint API.\n\n" +
                //    ex.Message,
                //    "CEPIMA",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
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

                    ShowUnknownAgentDialogOnUIThread();
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

                    ShowUnknownAgentDialogOnUIThread();
                    
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

        private void ShowUnknownAgentDialogOnUIThread()
        {
            try
            {
                if (Application.OpenForms.Count == 0)
                    return;

                Form mainForm = Application.OpenForms[0];

                Action action = delegate
                {
                    ShowUnknownAgentDialog();
                };

                if (mainForm.InvokeRequired)
                    mainForm.BeginInvoke(action);
                else
                    action();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Erreur ShowUnknownAgentDialog : " + ex.Message);
            }
        }


        // ========================================================
        // AGENT INCONNU
        // ========================================================

        private void ShowUnknownAgentDialog()
        {
            try
            {

                AgentNonReconnu unknown_fp = new AgentNonReconnu();
                Presence pres = new Presence(false, unknown_fp);
                pres.ShowDialog();

            }
            catch
            {

            }
        }


        // ========================================================
        // OUVRIR FORMULAIRE PERSONNEL
        // ========================================================




        // ========================================================
        // PROCHAIN FINGERPRINT ID
        // ========================================================



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
                            MessageBox.Show("Empreinte reconnue mais Agent non trouvé.");
                            ShowUnknownAgentDialogOnUIThread();
                            
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

                    //Il enregistre l'heure fixe, l'heure réelle d'entrée et le statut, puis déclenche l'enregistrement de la retenue si le personnel est en retard
                    TimeSpan heureFixe = new TimeSpan(8, 20, 0);

                    string sqlHeureFixe = @"
                            SELECT COLUMN_DEFAULT
                            FROM INFORMATION_SCHEMA.COLUMNS
                            WHERE TABLE_SCHEMA = DATABASE()
                              AND TABLE_NAME = 'presences'
                              AND COLUMN_NAME = 'heure_fixe'";

                    using (MySqlCommand cmd = new MySqlCommand(sqlHeureFixe, con))
                    {
                        object valeur = cmd.ExecuteScalar();

                        if (valeur != null && valeur != DBNull.Value)
                        {
                            string texte = valeur.ToString().Trim('\'');
                            TimeSpan heureLue;
                            if (TimeSpan.TryParse(texte, out heureLue))
                                heureFixe = heureLue;
                        }
                    }

                    bool estRetard;

                    using (MySqlCommand cmd = new MySqlCommand("SELECT CURTIME() > @heureFixe", con))
                    {
                        cmd.Parameters.Add("@heureFixe", MySqlDbType.Time).Value = heureFixe;
                        estRetard = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                    }

                    string statut = estRetard ? "Retard" : "Présent";

                    string insertSql = @"
        INSERT INTO presences
            (id_personnel, date_presence, heure_fixe, heure_entree, statut)
        VALUES
            (@id_personnel, CURDATE(), @heureFixe, CURTIME(), @statut)";

                    long idPresence;

                    using (MySqlCommand cmd = new MySqlCommand(insertSql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_personnel", personnelId);
                        cmd.Parameters.Add("@heureFixe", MySqlDbType.Time).Value = heureFixe;
                        cmd.Parameters.AddWithValue("@statut", statut);

                        cmd.ExecuteNonQuery();
                        idPresence = cmd.LastInsertedId;
                    }

                    if (estRetard)
                    {
                        EnregistrerRetenue(con, personnelId, idPresence, DateTime.Today);
                    }

                    heureEntree = DateTime.Now.ToString("HH:mm:ss");

                    SendResponse(context, 200,
                        "{\"success\":true,\"message\":\"" +
                        (estRetard ? "Présence enregistrée avec retard" : "Présence enregistrée") +
                        "\",\"fingerprint_id\":" + fingerprintId + ",\"score\":" + score + "}");

                    ShowAttendanceMessage(nom, postNom, prenom, "Entrée", heureEntree, score);

                    return;
                }


                // ------------------------------------------------
                // SORTIE
                // ------------------------------------------------

                if (string.IsNullOrWhiteSpace(heureSortie))
                {
                    // --------------------------------------------
                    // VERIFIER LE DELAI D'UNE HEURE DANS MYSQL
                    // --------------------------------------------

                    string checkSql =
                        "SELECT " +
                        "TIMESTAMPDIFF(SECOND, " +
                        "TIMESTAMP(date_presence, heure_entree), " +
                        "NOW()) AS duree_presence " +
                        "FROM presences " +
                        "WHERE id_personnel = @id_personnel " +
                        "AND date_presence = CURDATE() " +
                        "LIMIT 1";

                    long dureePresence = 0;

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            checkSql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            personnelId);

                        object resultat = cmd.ExecuteScalar();

                        if (resultat == null || resultat == DBNull.Value)
                        {
                            SendResponse(
                                context,
                                400,
                                "{\"success\":false," +
                                "\"message\":\"Impossible de vérifier la durée de présence\"}");

                            return;
                        }

                        dureePresence = Convert.ToInt64(resultat);
                    }

                    // --------------------------------------------
                    // REFUSER SI MOINS DE 60 MINUTES
                    // --------------------------------------------

                    if (dureePresence < 600)
                    {
                        long secondesRestantes = 600 - dureePresence;

                        int minutesRestantes =
                            (int)Math.Ceiling(secondesRestantes / 60.0);

                        SendResponse(
                            context,
                            400,
                            "{\"success\":false," +
                            "\"message\":\"Sortie non autorisée. Dix minutes de présence est obligatoire.\"," +
                            "\"minutes_restantes\":" +
                            minutesRestantes +
                            "}");
                        MessageBox.Show(
                            "Sortie non autorisée !\n\n" +
                            "Sortie non autorisée. Dix minutes de présence.\n\n" +
                            "Temps restant : " +
                            minutesRestantes +
                            " minute(s).",
                            "Contrôle de présence",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    // --------------------------------------------
                    // ENREGISTRER LA SORTIE
                    // --------------------------------------------

                    string updateSql =
                        "UPDATE presences " +
                        "SET heure_sortie = CURTIME() " +
                        "WHERE id_personnel = @id_personnel " +
                        "AND date_presence = CURDATE() " +
                        "AND heure_sortie IS NULL";

                    using (
                        MySqlCommand cmd =
                        new MySqlCommand(
                            updateSql,
                            con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_personnel",
                            personnelId);

                        int lignesModifiees = cmd.ExecuteNonQuery();

                        if (lignesModifiees == 0)
                        {
                            SendResponse(
                                context,
                                400,
                                "{\"success\":false," +
                                "\"message\":\"La sortie n'a pas pu être enregistrée\"}");

                            return;
                        }
                    }

                    heureSortie =
                        DateTime.Now.ToString("HH:mm:ss");

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

                MessageBox.Show("Présence déjà complète");
            }
        }


        // Enregistrer la retenues
        private void EnregistrerRetenue(MySqlConnection con, int personnelId, long idPresence, DateTime datePresence)
        {
            object idSalaire = DBNull.Value;
            string mois = datePresence.ToString("yyyy-MM");

            string sqlSalaire = @"
        SELECT id_salaire
        FROM salaires
        WHERE id_personnel = @idPersonnel
          AND mois = @mois
        ORDER BY id_salaire DESC
        LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(sqlSalaire, con))
            {
                cmd.Parameters.AddWithValue("@idPersonnel", personnelId);
                cmd.Parameters.AddWithValue("@mois", mois);

                object resultat = cmd.ExecuteScalar();

                if (resultat != null && resultat != DBNull.Value)
                    idSalaire = resultat;
            }

            string sqlRetenue = @"
                    INSERT INTO retenue
                        (id_salaire, id_presence, date_retenue, motif, montant)
                    SELECT
                        @idSalaire, @idPresence, @dateRetenue, 'Retard du personnel', 3.00
                    WHERE NOT EXISTS (
                        SELECT 1 FROM retenue WHERE id_presence = @idPresence
                    )";

            using (MySqlCommand cmd = new MySqlCommand(sqlRetenue, con))
            {
                cmd.Parameters.AddWithValue("@idSalaire", idSalaire);
                cmd.Parameters.AddWithValue("@idPresence", idPresence);
                cmd.Parameters.Add("@dateRetenue", MySqlDbType.Date).Value = datePresence.Date;

                cmd.ExecuteNonQuery();
            }

            if (idSalaire == DBNull.Value)
                Console.WriteLine("Retenue enregistrée sans salaire associé. Personnel : " + personnelId);
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
                    //MessageBox.Show(
                    //    "Agent : " +
                    //    nom +
                    //    " " +
                    //    postNom +
                    //    " " +
                    //    prenom +
                    //    "\n\n" +
                    //    type +
                    //    " : " +
                    //    heure +
                    //    "\n" +
                    //    "Score : " +
                    //    score,
                    //    "CEPIMA - Présence",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);

                    Control control = null;

                    if (type == "Sortie")
                    {
                        SignatureSortie signSortie = new SignatureSortie(
                            nom + " " + postNom + " " + prenom,
                            DateTime.Now.Date.ToString("dd/MM/yyyy"),
                            heure);

                        control = signSortie;
                    }

                    else
                    {
                        SignaturePresence signPresence = new SignaturePresence(
                        nom + " " + postNom + " " + prenom,
                        DateTime.Now.Date.ToString("dd/MM/yyyy"),
                        heure);

                        control = signPresence;
                    }

                    Cepima.MesForms.Personnel.Presence pres = new MesForms.Personnel.Presence(true, control);
                    pres.ShowDialog();
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