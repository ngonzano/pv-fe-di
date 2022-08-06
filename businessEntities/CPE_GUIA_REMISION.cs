using System;
using System.Collections.Generic;
using System.Data;

namespace businessEntities
{
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Jose Zambrano  (25/06/2018)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    // <summary> Entidad = CPE_GUIA </summary> //
    public class CPE_GUIA_REMISION
    {
        public Nullable<int> ID { get; set; }

        public string NRO_COMPROBANTE { get; set; }//T001-00003
        public string FECHA_DOCUMENTO { get; set; }
        public string COD_TIPO_DOCUMENTO { get; set; }//TAG (DespatchAdviceTypeCode) 09=guia remision remitente, 31=transportista
        public string NOTA { get; set; }//ESTO ES UNA GUIA DE REMISION OBSERVACIÓN

        //=====================DATOS DE ANULACION==========================
        public Nullable<int> FLG_ANULADO { get; set; }//0=NO ES ANULACION, 1=ANULACION
        public string DOC_REFERENCIA_ANU { get; set; }//DOCUMENTO DE REFERENCIA AL QUE SE ANULARA
        public string COD_TIPO_DOC_REFANU { get; set; }//TIPO DE DOCUMENTO DE REFENCIA (GUIA REMITENTE, GUIA TRANSPORTISTA)
        //=================DATOS DE ENVIO=================
        public Nullable<int> ITEM_ENVIO { get; set; }
        public string COD_MOTIVO_TRASLADO { get; set; }//TAG (HandlingCode) catalogo 20
        public string DESCRIPCION_MOTIVO_TRASLADO { get; set; }//TAG (Information) catalogo 20
        public string COD_UND_PESO_BRUTO { get; set; }//TAG (GrossWeightMeasure) catalogo 3
        public Nullable<decimal> PESO_BRUTO { get; set; }
        public Nullable<int> TOTAL_BULTOS { get; set; }//TAG (TotalTransportHandlingUnitQuantity) cantidad total de bultos o palet's

        //=================INICIO DE TRASLADO Y DATOS DEL TRANSPORTISTA=================
        public string COD_MODALIDAD_TRASLADO { get; set; }//TAG (TransportModeCode) catalogo 18, 01=transporte publico, 02=transporte privado
        public string FECHA_INICIO { get; set; }//TAG (StartDate)

        //=======================DATOS DEL TRANSPORTISTA PUBLICO======================
        public string NRO_DOCUMENTO_TRANSPORTISTA { get; set; }
        public string RAZON_SOCIAL_TRANSPORTISTA { get; set; }
        public string TIPO_DOCUMENTO_TRANSPORTISTA { get; set; }//6=RUC

        //=========================DATOS VEHICULO, CHOFER, CARROZA - UND TRANSPORTE========================
        public string PLACA_VEHICULO { get; set; }
        public string COD_TIPO_DOC_CHOFER { get; set; }//1=DNI
        public string NRO_DOC_CHOFER { get; set; }//NRO DOCUMENTO DEL CHOFER
        public string PLACA_CARRETA { get; set; }

        //=======================DATOS DEL CLIENTE======================
        public string NRO_DOCUMENTO_CLIENTE { get; set; }
        public string RAZON_SOCIAL_CLIENTE { get; set; }
        public string TIPO_DOCUMENTO_CLIENTE { get; set; }//6=RUC       

        //=======================DATOS DE LA EMPRESA======================
        public string NRO_DOCUMENTO_EMPRESA { get; set; }
        public string TIPO_DOCUMENTO_EMPRESA { get; set; }//6=RUC
        public string RAZON_SOCIAL_EMPRESA { get; set; }

        //=======================DIRECCION PARTIDA-LLEGADA======================
        //-----------LLEGADA (DeliveryAddress)
        public string COD_UBIGEO_DESTINO { get; set; }
        public string DIRECCION_DESTINO { get; set; }// TAG (StreetName)
        //-----------PARTIDA (OriginAddress)
        public string COD_UBIGEO_ORIGEN { get; set; }
        public string DIRECCION_ORIGEN { get; set; }// TAG (StreetName)

        //=======================DATOS DE LA SUNAT======================
        public Nullable<int> TIPO_PROCESO { get; set; }
        public string USUARIO_SOL_EMPRESA { get; set; }
        public string PASS_SOL_EMPRESA { get; set; }
        public string CONTRA_FIRMA { get; set; }

        //=================rutas===================
        public string RUTA_PDF { get; set; }
        public string RUTA_CODIGO_BARRA { get; set; }
        public string RUTA_FIRMA { get; set; }
        public string RUTA_XML { get; set; }
        public string RUTA_URL_WEB { get; set; }
        /////////detalle////////
        public List<CPE_GUIA_REMISION_DETALLE> detalle = new List<CPE_GUIA_REMISION_DETALLE>();
    }
}
