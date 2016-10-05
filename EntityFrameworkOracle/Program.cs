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
                //string code = "";

                //// si le codecours de l'élément est le même que celui précédent, n'afficher que la date
                //foreach (var unSeminaire in lesSeminaires)
                //{
                //    if (code != unSeminaire.CODECOURS)
                //    {
                //        var count = (from s in oracleContext.SEMINAIREs
                //                     join COUR in oracleContext.COURS on s.CODECOURS equals COUR.CODECOURS
                //                     where s.CODECOURS == unSeminaire.CODECOURS
                //                     select s).Count();
                //        code = unSeminaire.CODECOURS;
                //        Console.WriteLine(unSeminaire.CODECOURS + " - " + unSeminaire.CODECOURS + " - " + unSeminaire.COUR.LIBELLECOURS);
                //        Console.WriteLine("\t\t" + unSeminaire.DATEDEBUTSEM);
                //    }
                //    else
                //    {
                //        Console.WriteLine("\t\t" + unSeminaire.DATEDEBUTSEM);
                //    }

                //}

                foreach (var unCours in lesCours)
                {
                    Console.WriteLine(unCours.CODECOURS + " - " + unCours.LIBELLECOURS);
                    var getDates = from s in oracleContext.SEMINAIREs
                                   where unCours.CODECOURS == s.CODECOURS
                                   select s;

                    foreach (var date in getDates.ToList())
                        Console.WriteLine("\t\t" + date.DATEDEBUTSEM);
                }



                Console.Read();

            }
        }
    }
}
            
        
    

