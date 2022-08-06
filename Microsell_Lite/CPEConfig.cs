using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//FE
using BE = businessEntities;
using XM = CrearXML;
using EV = CPEEnvio;
using SG = Signature;

namespace Microsell_Lite
{
    public class CPEConfig
    {
        XM.CrearXML objXml = new XM.CrearXML();
        SG.FirmadoRequest objPregunta = new SG.FirmadoRequest();
        SG.FirmadoResponse objRespuesta = new SG.FirmadoResponse();
        SG.Signature objsignature = new SG.Signature();
        EV.ServiceSunat objEnv = new EV.ServiceSunat();
        

        public string RutaCompleta_XML = "";

        public Dictionary<string,string> Enviar_Boleta_Factura_Sunat(BE.CPE CPE)
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            string NomArchivo = "";
            string ruta = "";
            string rutaFirma = "";
            string url="";

            NomArchivo = CPE.NRO_DOCUMENTO_EMPRESA + "-" + CPE.COD_TIPO_DOCUMENTO + "-" + CPE.NRO_COMPROBANTE;//20448307447-01-FE01-000001
            if (CPE.TIPO_PROCESO==3)
            {
                //SERVIDOR DE PRUEBAS
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
              //url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
                url = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
            }
            if (CPE.TIPO_PROCESO == 1)
            {
                //SERVIDOR DE produccion
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
              //url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
            }
            //el nombre del archivo varia segun la empresa
            rutaFirma = @"C:\\Sln_MicrosellLite\\CPE_2\\FIRMABETA\\FIRMABETA.pfx"; //
            //creamos el xml
            if (CPE.COD_TIPO_DOCUMENTO=="01" | CPE.COD_TIPO_DOCUMENTO == "03")
            {
                dictonary = objXml.CPE(CPE,NomArchivo,ruta);
            }
            //Mostrara la respuesta
            if (dictonary["flg_rta"] == "0")
            {
                return dictonary;
            }

            //datos para la firma de documento
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + NomArchivo + ".XML";
            RutaCompleta_XML= ruta + NomArchivo + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objsignature.FirmaXMl(objPregunta);

            //enviando a la sunat
            dictonary = objEnv.Envio(CPE.NRO_DOCUMENTO_EMPRESA,CPE.USUARIO_SOL_EMPRESA,CPE.PASS_SOL_EMPRESA,NomArchivo,ruta,url,objRespuesta.DigestValue);
            CPE.HASH_CPE = dictonary["hash_cpe"];
            CPE.HASH_CDR = dictonary["hash_cdr"];
            CPE.COD_RESPUESTA_SUNAT= dictonary["cod_sunat"];
            CPE.DESCRIPCION_RESPUESTA= dictonary["msj_sunat"];
            return dictonary;
        }
        public Dictionary<string, string> Enviar_NotaCredito_aSunat(BE.CPE CPE)
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            string NomArchivo = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            NomArchivo = CPE.NRO_DOCUMENTO_EMPRESA + "-" + CPE.COD_TIPO_DOCUMENTO + "-" + CPE.NRO_COMPROBANTE;//20448307447-01-FE01-000001
            if (CPE.TIPO_PROCESO == 3)
            {
                //SERVIDOR DE PRUEBAS
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
            }
            if (CPE.TIPO_PROCESO == 1)
            {
                //SERVIDOR DE produccion
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
            }
            //el nombre del archivo varia segun la empresa
            rutaFirma = @"C:\\Sln_MicrosellLite\\CPE_2\\FIRMABETA\\FIRMABETA.pfx"; //
            //creamos el xml
            if (CPE.COD_TIPO_DOCUMENTO == "07")
            {
                dictonary = objXml.CPE_NC(CPE, NomArchivo, ruta);
            }
            //Mostrara la respuesta
            if (dictonary["flg_rta"] == "0")
            {
                return dictonary;
            }

            //datos para la firma de documento
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + NomArchivo + ".XML";
            RutaCompleta_XML = ruta + NomArchivo + ".XML";
            objPregunta.flg_firma = 0;
            objRespuesta = objsignature.FirmaXMl(objPregunta);

            //enviando a la sunat
            dictonary = objEnv.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, NomArchivo, ruta, url, objRespuesta.DigestValue);
            CPE.HASH_CPE = dictonary["hash_cpe"];
            CPE.HASH_CDR = dictonary["hash_cdr"];
            CPE.COD_RESPUESTA_SUNAT = dictonary["cod_sunat"];
            CPE.DESCRIPCION_RESPUESTA = dictonary["msj_sunat"];
            return dictonary;
        }
        public Dictionary<string, string> Enviar_Resumen_Boletas(BE.CPE_RESUMEN_BOLETA objResumen)
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            string NomArchivo = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            NomArchivo = objResumen.NRO_DOCUMENTO_EMPRESA + "-" + objResumen.CODIGO + "-"+objResumen.SERIE+ "-" + objResumen.SECUENCIA; //20100066603-RC-20110522-00001.XML
            //NomArchivo = objResumen.CODIGO + "-"+ objResumen.SERIE +"-"+ objResumen.SECUENCIA;
            if (objResumen.TIPO_PROCESO == 3)
            {
                //SERVIDOR DE PRUEBAS
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
            }
            if (objResumen.TIPO_PROCESO == 1)
            {
                //SERVIDOR DE produccion
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
            }
            //el nombre del archivo varia segun la empresa
            rutaFirma = @"C:\\Sln_MicrosellLite\\CPE_2\\FIRMABETA\\FIRMABETA.pfx"; //

            dictonary = objXml.ResumenBoleta(objResumen,NomArchivo,ruta);

            //Mostrara la respuesta
            if (dictonary["flg_rta"] == "0")
            {
                return dictonary;
            }

            //datos para la firma de documento
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = objResumen.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + NomArchivo + ".XML";
            RutaCompleta_XML = ruta + NomArchivo + ".XML";
            objPregunta.flg_firma = 0;//validar no agrega
            objRespuesta = objsignature.FirmaXMl(objPregunta);//validar no agrega
            
            //enviando a la sunat
            dictonary = objEnv.EnvioResumen(objResumen.NRO_DOCUMENTO_EMPRESA, objResumen.USUARIO_SOL_EMPRESA, objResumen.PASS_SOL_EMPRESA, NomArchivo, ruta, url, objRespuesta.DigestValue);
            objResumen.HASH_CPE = dictonary["hash_cpe"];
            objResumen.HASH_CDR = dictonary["hash_cdr"];
            objResumen.COD_RESPUESTA_SUNAT = dictonary["cod_sunat"];
            objResumen.DESCRIPCION_RESPUESTA = dictonary["msj_sunat"];
            return dictonary;
        }
        public Dictionary<string, string> Consulta_Ticket_de_Baja(BE.CONSULTA_TICKET objResumen)
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            string NomArchivo = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            NomArchivo = objResumen.NRO_DOCUMENTO_EMPRESA + "-" + objResumen.TIPO_DOCUMENTO + "-" + objResumen.NRO_DOCUMENTO;

            if (objResumen.TIPO_PROCESO == 3)
            {
                //SERVIDOR DE PRUEBAS
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
            }
            if (objResumen.TIPO_PROCESO == 1)
            {
                //SERVIDOR DE produccion
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
            }
            dictonary = objEnv.ConsultaTicket(objResumen.NRO_DOCUMENTO_EMPRESA, objResumen.USUARIO_SOL_EMPRESA, objResumen.PASS_SOL_EMPRESA, NomArchivo, ruta, url, objRespuesta.DigestValue,objResumen.TICKET);
            
            return dictonary;
        }
        public Dictionary<string, string> Enviar_Baja_de_FE(BE.CPE_BAJA objBaja)
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            string NomArchivo = "";
            string ruta = "";
            string rutaFirma = "";
            string url = "";

            NomArchivo = objBaja.NRO_DOCUMENTO_EMPRESA + "-" + objBaja.CODIGO + "-" + objBaja.SERIE + "-" + objBaja.SECUENCIA; //20100066603-RA-20110522-00001.ZIP
            //NomArchivo = objResumen.CODIGO + "-"+ objResumen.SERIE +"-"+ objResumen.SECUENCIA;
            if (objBaja.TIPO_PROCESO == 3)
            {
                //SERVIDOR DE PRUEBAS
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService";
            }
            if (objBaja.TIPO_PROCESO == 1)
            {
                //SERVIDOR DE produccion
                ruta = @"C:\\Sln_MicrosellLite\\CPE_2\\BETA\\";
                url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService";
            }
            //el nombre del archivo varia segun la empresa
            rutaFirma = @"C:\\Sln_MicrosellLite\\CPE_2\\FIRMABETA\\FIRMABETA.pfx"; //

            dictonary = objXml.ResumenBaja(objBaja, NomArchivo, ruta);

            //Mostrara la respuesta
            if (dictonary["flg_rta"] == "0")
            {
                return dictonary;
            }

            //datos para la firma de documento
            objPregunta.ruta_Firma = rutaFirma;
            objPregunta.contra_Firma = objBaja.CONTRA_FIRMA;
            objPregunta.ruta_xml = ruta + NomArchivo + ".XML";
            //RutaCompleta_XML = ruta + NomArchivo + ".XML";
            objPregunta.flg_firma = 0;//validar no agrega
            objRespuesta = objsignature.FirmaXMl(objPregunta);//validar no agrega

            //enviando a la sunat
            dictonary = objEnv.EnvioResumen(objBaja.NRO_DOCUMENTO_EMPRESA, objBaja.USUARIO_SOL_EMPRESA, objBaja.PASS_SOL_EMPRESA, NomArchivo, ruta, url, objRespuesta.DigestValue);
            objBaja.HASH_CPE = dictonary["hash_cpe"];
            objBaja.HASH_CDR = dictonary["hash_cdr"];
            //objBaja.COD_RESPUESTA_SUNAT = dictonary["cod_sunat"];
            objBaja.DESCRIPCION_RESPUESTA = dictonary["msj_sunat"];
            return dictonary;
        }
    }
}
