using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (OracleEntities oracleContext = new OracleEntities())
            {
                // on va afficher tous les employes
                // requete linq
                var requeteEmployes = from EMPLOYE in oracleContext.EMPLOYEs
                                      select EMPLOYE;

                // exécution de la requete
                var lesEmployes = requeteEmployes.ToList();

                // affichage du resultat
                foreach (var unEmploye in lesEmployes)
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);

                Console.WriteLine("--------------------------------------------------");

                var unCodeProjet = "PR1";
                var requeteEmployesProjet = from EMPLOYE in oracleContext.EMPLOYEs
                                            where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                            select EMPLOYE;

                var lesEmployesProjet = requeteEmployesProjet.ToList();

                foreach (var unEmploye in lesEmployesProjet)
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);

                Console.WriteLine("--------------------------------------------------");

                var idEmploye = 33;
                var requeteEmployesById = from EMPLOYE in oracleContext.EMPLOYEs
                                          where EMPLOYE.NUMEMP == idEmploye
                                          select EMPLOYE;

                var employeId = requeteEmployesById.FirstOrDefault();

                if (employeId != null)
                    Console.WriteLine(employeId.NOMEMP + " - " + employeId.PRENOMEMP + " - " + employeId.SALAIRE + " euro(s)");
                else
                    Console.WriteLine("L'employé numéro " + idEmploye + " n'existe pas.");

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("----           Cours et séminaires           -----");
                Console.WriteLine("--------------------------------------------------");

                var requete = from s in oracleContext.COURS
                              select s;
                var lesCours = requete.ToList();

                foreach (var unCours in lesCours)
                {
                    Console.WriteLine(unCours.CODECOURS + " - " + unCours.LIBELLECOURS);
                    foreach (var date in unCours.SEMINAIREs)
                        Console.WriteLine("\t\t" + date.DATEDEBUTSEM);
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("----     Nombre d'employer par projet v1     -----");
                Console.WriteLine("--------------------------------------------------");

                var employeProjet = from emp in oracleContext.EMPLOYEs
                                    group emp by emp.CODEPROJET into groupeEmployes
                                    select new
                                    {
                                        Projet = groupeEmployes.Key,
                                        Nombre = groupeEmployes.Count()
                                    };
                foreach (var ligne in employeProjet.ToList())
                    Console.WriteLine(ligne.Projet + " - " + ligne.Nombre);

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("----     Nombre d'employer par projet v2     -----");
                Console.WriteLine("--------------------------------------------------");

                var empProjetNom = from emp in oracleContext.EMPLOYEs
                                   join PROJET in oracleContext.PROJETs on emp.CODEPROJET equals PROJET.CODEPROJET
                                   group emp by new { emp.CODEPROJET, PROJET.NOMPROJET } into groupeEmployes
                                   select new
                                   {
                                       Projet = groupeEmployes.Key.CODEPROJET,
                                       Nom = groupeEmployes.Key.NOMPROJET,
                                       Nombre = groupeEmployes.Count()
                                   };

                foreach(var ligne in empProjetNom.ToList())
                    Console.WriteLine(ligne.Projet + " - " + ligne.Nom + " - " + ligne.Nombre);

                // PARTIE 4
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("----                  PARTIE 4               -----");
                Console.WriteLine("--------------------------------------------------");
                var requeteP4 = from s in oracleContext.COURS
                              select s;
                foreach (var unCours in requeteP4.ToList())
                    Console.WriteLine(unCours);
                var requeteEmpP4 = from e in oracleContext.EMPLOYEs
                                   select e;
                Console.WriteLine("--------------------------------------------------");
                foreach(var unEmp in requeteEmpP4.ToList())
                    Console.WriteLine(unEmp);


                Console.Read();

            }
        }
    }
}
            
        
    

