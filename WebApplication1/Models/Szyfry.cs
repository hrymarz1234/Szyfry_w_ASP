using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Szyfry
    {

        public string tekst { get; set; }
        public int przesuniecie { get; set; }
        public static string szyfr_cezara(string tekst, int przesuniecie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string pom = "";
            string pom2 = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] != ' ')
                {
                    pom += tekst[i];
                }

            }
            for (int l = 0; l < pom.Length; l++)
            {
                for (int j = 0; j < tab2.Length; j++)
                {
                    if (pom[l] == tab2[j])
                    {
                        pom2 += tab[j];
                    }
                    else if (pom[l] == tab[j])
                    {
                        pom2 += tab[j];
                    }

                }

            }
            pom = "";
            for (int k = 0; k < pom2.Length; k++)
            {
                for (int y = 0; y < tab.Length; y++)
                {

                    if (pom2[k] == tab[y])
                        pom += tab[(y + przesuniecie) % 35];
                }
            }
            return pom;
        }
    }
}

            
        

