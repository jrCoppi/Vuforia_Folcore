using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Assets.Scripts.Cenario
{
    public class Tabuleiro : MonoBehaviour
    {
        void Start()
        {
            Jogo.Instance.IniciarJogo();
        }

        void Update()
        {

        }

        public static void finalizarJogo()
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("folclore_furb@hotmail.com");
            mail.To.Add("folclore_furb@hotmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "Pontuação do jogo foi:" + Jogo.Instance.Pontuacao;

            SmtpClient smtpServer = new SmtpClient("smtp.live.com");
            smtpServer.Port = 587;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new System.Net.NetworkCredential("folclore_furb@hotmail.com", "folclore123") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            smtpServer.Send(mail);
            //UnityEditor.EditorUtility.DisplayDialog("Fim!", "Final de Jogo.", "Ok");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
					Application.Quit();
#endif
        }
    }
}
