using Assets.Scripts.Cenario;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(ShowGameOver());
        SendEmail();
    }

    //public IEnumerator ShowGameOver()
    //{
    //   SendEmail();
    //}

    private void SendEmail()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("folclore_furb@hotmail.com");
        mail.To.Add("folclore_furb@hotmail.com");
        mail.Subject = "Mais uma partida no jogo do Folclore";
        mail.Body = Jogo.Instance.JogadorAtual + ", sua pontuação do jogo foi:" + Jogo.Instance.Pontuacao;

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

    // Update is called once per frame
    void Update()
    {

    }
}
