using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MailSenderV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MimeMessage message = new MimeMessage();
            Console.Write("N'utilisé pas gmail, outlook ou yahoo comme email d'envoie, préferer gmx");
            Console.Write("Email pour envoyer:");
            string emailAdress = Console.ReadLine();
            Console.Write("Mot de Passe:");
            string password = Console.ReadLine();
            //Création du message à l'aide de la librairie MimeMessage
            message.From.Add(new MailboxAddress("e-mail sender", emailAdress));
            //Initialisation des informations qui s'afficheront (nom, email) sur la boite mail de receveur
            Console.Write("Adresse e-mail de la cible:");
            string cible = Console.ReadLine();
            message.To.Add(MailboxAddress.Parse(cible));
            //Initialisation de l'email du receveur
            Console.Write("Objet:");
            string objet = Console.ReadLine();
            message.Subject = objet;
            //Initialisation de l'objet du mail
            Console.Write("Message:");
            //Demande le message a envoyer
            string messageu = Console.ReadLine();
            //Associe à messageu le message à envoyer
            message.Body = new TextPart("plain")
            {
                Text = @messageu
            };
            //Initialisation du corp/texte
            
            
            //La console recupère les données de l'email avec laquelle elle va envoyer le mail

            SmtpClient client = new SmtpClient();
            //Initialisation du client à l'aide de la librairie SmtpClient

            Console.Write("server smtp de l'email pour envoyer");
            Console.Write("exemple: pour gmx c'est mail.gmx.com");
            string smtp = Console.ReadLine();
            Console.Write("port de l'adresse, en général, c'est 465");
            string port = Console.ReadLine();

            try
            {
                client.Connect(smtp, Int32.Parse(port), true);
                //Paramètre l'adresse SMTP, le port et l'activation du protocole cryptographique SSL
                client.Authenticate(emailAdress, password);
                client.Send(message);
                //S'authentifie et envoie le mail

                Console.WriteLine("email envoyé");
                Console.ReadLine();
                //Confirme l'envoie du message
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Renvoie l'erreur renvoyer par le service de messagerie si il y en a une lors de l'authentification
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
                //Se déconnecte et libère les ressources
                string x = Console.ReadLine();
            }
        }
    }
}
