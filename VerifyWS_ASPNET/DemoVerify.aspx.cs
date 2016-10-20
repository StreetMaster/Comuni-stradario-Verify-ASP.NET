using System;

namespace VerifyWS_ASPNET
{
    /// <summary>
    /// Esempio di utilizzo del servizio WS VERIFY per la verifica e la normalizzazione degli indirizzi italiani 
    /// realizzato da StreetMaster Italia
    /// 
    /// L'end point del servizio è 
    ///     http://ec2-46-137-97-173.eu-west-1.compute.amazonaws.com/smws/verify?wsdl
    ///     
    /// Per l'utilizzo registrarsi sul sito http://streetmaster.it e richiedere la chiave per il servizio VERIFY 
    /// 
    /// 2016 - Software by StreetMaster (c)
    /// </summary>
    public partial class DemoVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCallVerify_Click(object sender, EventArgs e)
        {

            outArea.Style["Border"] = "none";
            outArea.Style["Border-color"] = "#336600";

            // oggetto client per l'utilizzo del ws FILL
            var verifyObj = new VerifyWS.verify();

            // classe di input
            var inVerify = new VerifyWS.inputCommon();

            // valorizzazione input
            inVerify.cap = txtCap.Text;
            inVerify.provincia = txtProv.Text;
            inVerify.localita = txtComune.Text;
            inVerify.localita2 = txtFrazione.Text;
            inVerify.indirizzo = txtIndirizzo.Text;

            // chiamata al servizio
            var outCall = verifyObj.Verify(inVerify, txtKey.Text);


            if (outCall.norm==1)
            {
                // verifica OK
                txtCap.Text = outCall.outItem[0].cap;
                txtProv.Text= outCall.outItem[0].provincia;
                txtComune.Text = outCall.outItem[0].comune;
                txtFrazione.Text = outCall.outItem[0].frazione;
                txtIndirizzo.Text = outCall.outItem[0].indirizzo;
                outArea.InnerHtml = "<p><font color=\"green\">INDIRIZZO VALIDO</font></p>";
            }
            else
            {
                // verifica KO, gestione errore

                // errore di licenza
                if (outCall.codErr == 997)
                    outArea.InnerHtml = "<p><font color=\"red\">LICENSE KEY NON RICONOSCIUTA</font></p>";
                else if (outCall.codErr == 123)
                    outArea.InnerHtml = "<p><font color=\"red\">NON E' STATO VALORIZZATO IL COMUNE</font></p>";
                else if (outCall.codErr == 124)
                    outArea.InnerHtml = "<p><font color=\"red\">COMUNE\\FRAZIONE NON RICONOSCIUTO</font></p>";
                else if (outCall.codErr == 125)
                {
                    String htmlOut= "<p><font color=\"red\">COMUNE\\FRAZIONE AMBIGUO</font></p>";

                    htmlOut += "<table>";
                    foreach (VerifyWS.outVerify outElem in outCall.outItem)
                    {
                        htmlOut += "<tr><td>";

                        htmlOut += outElem.cap + " "+ outElem.comune+ " " + outElem.provincia;
                        if (outElem.frazione != string.Empty)
                            htmlOut += " - " + outElem.frazione;
                        htmlOut += "</td></tr>";
                    }
                    htmlOut += "</table>";
                    outArea.InnerHtml = htmlOut;
                }
                else if (outCall.codErr == 466)
                {
                    txtCap.Text = outCall.outItem[0].cap;
                    txtProv.Text = outCall.outItem[0].provincia;
                    txtComune.Text = outCall.outItem[0].comune;
                    txtFrazione.Text = outCall.outItem[0].frazione;
                    outArea.InnerHtml = "<p><font color=\"red\">NON E' STATO VALORIZZATO L'INDIRIZZO</font></p>";
                }
                else if (outCall.codErr == 467)
                {
                    txtCap.Text = outCall.outItem[0].cap;
                    txtProv.Text = outCall.outItem[0].provincia;
                    txtComune.Text = outCall.outItem[0].comune;
                    txtFrazione.Text = outCall.outItem[0].frazione;
                    outArea.InnerHtml = "<p><font color=\"red\">INDIRIZZO NON RICONOSCIUTO</font></p>";
                }
                else if (outCall.codErr == 468)
                {
                    txtCap.Text = outCall.outItem[0].cap;
                    txtProv.Text = outCall.outItem[0].provincia;
                    txtComune.Text = outCall.outItem[0].comune;
                
                    String htmlOut = "<p><font color=\"red\">INDIRIZZO AMBIGUO</font></p>";
                    htmlOut += "<table>";
                    foreach (VerifyWS.outVerify outElem in outCall.outItem)
                    {
                        htmlOut += "<tr><td>";

                        htmlOut += outElem.cap + " " + outElem.indirizzo;
                        if (outElem.frazione != string.Empty)
                            htmlOut += " (" + outElem.frazione + ")";
                        htmlOut += "</td></tr>";
                    }
                    htmlOut += "</table>";
                    outArea.InnerHtml = htmlOut;
                }
                else if (outCall.codErr == 455)
                {
                    txtCap.Text = outCall.outItem[0].cap;
                    txtProv.Text = outCall.outItem[0].provincia;
                    txtComune.Text = outCall.outItem[0].comune;
                    txtFrazione.Text = outCall.outItem[0].frazione;
                    txtIndirizzo.Text = outCall.outItem[0].indirizzo;
                    outArea.InnerHtml = "<p><font color=\"red\">CAP INCONGRUENTE SU VIA MULTICAP</font></p>";
                }
            }
            outArea.Style["Border"] = "groove";
        }
    }
}