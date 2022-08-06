Imports System.IO
Imports System.Xml


Public Class ServiceSunat

    Public Function Envio(ruc As String, usu_sol As String, contra_sol As String, nombre_archivo As String, rutaArchivo As String, url As String, hash_cpe As String) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim strCDR As String
            Dim strSOAP As String
            Dim rutaCompleta As String = rutaArchivo & nombre_archivo
            Comprimir(nombre_archivo, rutaArchivo)
            Dim rutaCdr As String = rutaArchivo & "R-" & nombre_archivo & ".ZIP"
            Dim NomFichierZIP As String = System.IO.Path.GetFileName(rutaCompleta & ".ZIP")
            Dim data As Byte() = System.IO.File.ReadAllBytes(rutaCompleta & ".ZIP")

            strSOAP = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' " &
                    "xmlns:ser='http://service.sunat.gob.pe' " &
                    "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'> " &
                    "<soapenv:Header> " &
                    "<wsse:Security> " &
                    "<wsse:UsernameToken> " &
                    "<wsse:Username>" & ruc & usu_sol & "</wsse:Username> " &
                    "<wsse:Password>" & contra_sol & "</wsse:Password> " &
                    "</wsse:UsernameToken> " &
                    "</wsse:Security> " &
                    "</soapenv:Header> " &
                    "<soapenv:Body> " &
                    "<ser:sendBill> " &
                    "<fileName>" & NomFichierZIP & "</fileName> " &
                    "<contentFile>" & Convert.ToBase64String(data) & "</contentFile> " &
                    "</ser:sendBill> " &
                    "</soapenv:Body> " &
                    "</soapenv:Envelope>"


            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object



            strPostData = strSOAP
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "application/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("mensaje", "ERROR AL ENVIAR A LA SUNAT")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultcode").InnerText.Replace("soap-env:Client.", ""))
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//faultstring").InnerText)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", hash_cpe)
            Else
                strCDR = doc.SelectSingleNode("//applicationResponse").InnerText
                Dim byteCDR As Byte() = Convert.FromBase64String(strCDR)
                Dim s As IO.FileStream
                s = IO.File.Open(rutaCdr, IO.FileMode.Append)
                s.Write(byteCDR, 0, byteCDR.Length)
                s.Close()

                '===============descomprimo el xml=============
                Descomprimir(rutaArchivo, "R-" & nombre_archivo)
                '================================================================
                Dim xmlCDR As New XmlDocument()
                Dim rutaxmlCDR = rutaArchivo & "R-" & nombre_archivo & ".XML"
                xmlCDR.Load(rutaxmlCDR)

                '=======================nombre de espacios para obtener los valores del xml======================
                Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                Dim nsmgrSing As New XmlNamespaceManager(doc.NameTable)
                nsmgrSing.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

                '========================asignamos valores de retorno======================
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "1")
                dictionary.Add("mensaje", "COMPROBANTE ENVIADO CORRECTAMENTE")
                dictionary.Add("cod_sunat", xmlCDR.SelectSingleNode("//cbc:ResponseCode", nsmgr).InnerText)
                dictionary.Add("msj_sunat", xmlCDR.SelectSingleNode("//cbc:Description", nsmgr).InnerText.ToUpper)
                dictionary.Add("hash_cdr", xmlCDR.SelectSingleNode("//ds:DigestValue", nsmgrSing).InnerText)
                dictionary.Add("hash_cpe", hash_cpe)
                '=============eliminas el archivo comprimido que enviamos===============
                File.Delete(rutaCompleta & ".ZIP")
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working
        Catch ex As Exception
            'MsgBox("Error al Enviar Doc a Sunat: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Advertencia de Seguridad")
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", hash_cpe)
        End Try
        Return dictionary
    End Function



    Public Function EnvioGuiaRemision(ruc As String, usu_sol As String, contra_sol As String, nombre_archivo As String, rutaArchivo As String, url As String, hash_cpe As String) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim strCDR As String
            Dim strSOAP As String
            Dim rutaCompleta As String = rutaArchivo & nombre_archivo
            Comprimir(nombre_archivo, rutaArchivo)
            Dim rutaCdr As String = rutaArchivo & "R-" & nombre_archivo & ".ZIP"
            Dim NomFichierZIP As String = System.IO.Path.GetFileName(rutaCompleta & ".ZIP")
            Dim data As Byte() = System.IO.File.ReadAllBytes(rutaCompleta & ".ZIP")

            strSOAP = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' " &
                    "xmlns:ser='http://service.sunat.gob.pe' " &
                    "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'> " &
                    "<soapenv:Header> " &
                    "<wsse:Security> " &
                    "<wsse:UsernameToken> " &
                    "<wsse:Username>" & ruc & usu_sol & "</wsse:Username> " &
                    "<wsse:Password>" & contra_sol & "</wsse:Password> " &
                    "</wsse:UsernameToken> " &
                    "</wsse:Security> " &
                    "</soapenv:Header> " &
                    "<soapenv:Body> " &
                    "<ser:sendBill> " &
                    "<fileName>" & NomFichierZIP & "</fileName> " &
                    "<contentFile>" & Convert.ToBase64String(data) & "</contentFile> " &
                    "</ser:sendBill> " &
                    "</soapenv:Body> " &
                    "</soapenv:Envelope>"


            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object

            strPostData = strSOAP
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "application/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                Dim xmsmsunt As String = ""
                Dim xcod As String = ""
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultstring").InnerText.Replace("soap-env:Client.", ""))
                xcod = doc.SelectSingleNode("//faultstring").InnerText.Replace("soap-env:Client.", "")
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//message").InnerText)
                xmsmsunt = doc.SelectSingleNode("//message").InnerText
                MsgBox("Error al Enviar a la Sunat" & vbCrLf & "Codigo: " & xcod & vbCrLf & xmsmsunt, MsgBoxStyle.Exclamation, "Advertencia de Seguridad")
                dictionary.Add("mensaje", "ERROR AL ENVIAR A LA SUNAT" & vbCrLf & "Codigo: " & xcod & vbCrLf & xmsmsunt)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", hash_cpe)

                ''Nuevo metodo de Captura:


            Else
                strCDR = doc.SelectSingleNode("//applicationResponse").InnerText
                Dim byteCDR As Byte() = Convert.FromBase64String(strCDR)
                Dim s As IO.FileStream
                s = IO.File.Open(rutaCdr, IO.FileMode.Append)
                s.Write(byteCDR, 0, byteCDR.Length)
                s.Close()

                '===============descomprimo el xml=============
                Descomprimir(rutaArchivo, "R-" & nombre_archivo)
                '================================================================
                Dim xmlCDR As New XmlDocument()
                Dim rutaxmlCDR = rutaArchivo & "R-" & nombre_archivo & ".XML"
                xmlCDR.Load(rutaxmlCDR)

                '=======================nombre de espacios para obtener los valores del xml======================
                Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                Dim nsmgrSing As New XmlNamespaceManager(doc.NameTable)
                nsmgrSing.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

                '========================asignamos valores de retorno======================
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "1")
                dictionary.Add("mensaje", "COMPROBANTE ENVIADO CORRECTAMENTE")
                'MsgBox("El Documento fue Enviado y Aceptado por la Sunat", MsgBoxStyle.Information, "Envio a Sunat")
                dictionary.Add("cod_sunat", xmlCDR.SelectSingleNode("//cbc:ResponseCode", nsmgr).InnerText)
                dictionary.Add("msj_sunat", xmlCDR.SelectSingleNode("//cbc:Description", nsmgr).InnerText.ToUpper)
                dictionary.Add("hash_cdr", xmlCDR.SelectSingleNode("//ds:DigestValue", nsmgrSing).InnerText)
                dictionary.Add("hash_cpe", hash_cpe)
                '=============eliminas el archivo comprimido que enviamos===============
                File.Delete(rutaCompleta & ".ZIP")
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working


        Catch ex As Exception
            MsgBox("Error al Enviar Guia a Sunat: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Advertencia de Seguridad")
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", hash_cpe)
        End Try
        Return dictionary
    End Function

    Public Function EnvioResumen(ruc As String, usu_sol As String, contra_sol As String, nombre_archivo As String, rutaArchivo As String, url As String, hash_cpe As String) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim ticket As String
            Dim strSOAP As String
            Dim rutaCompleta As String = rutaArchivo & nombre_archivo
            Comprimir(nombre_archivo, rutaArchivo)
            Dim rutaCdr As String = rutaArchivo & "R-" & nombre_archivo & ".ZIP"
            Dim NomFichierZIP As String = System.IO.Path.GetFileName(rutaCompleta & ".ZIP")
            Dim data As Byte() = System.IO.File.ReadAllBytes(rutaCompleta & ".ZIP")

            strSOAP = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' " &
                    "xmlns:ser='http://service.sunat.gob.pe' " &
                    "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'> " &
                    "<soapenv:Header> " &
                    "<wsse:Security> " &
                    "<wsse:UsernameToken> " &
                    "<wsse:Username>" & ruc & usu_sol & "</wsse:Username> " &
                    "<wsse:Password>" & contra_sol & "</wsse:Password> " &
                    "</wsse:UsernameToken> " &
                    "</wsse:Security> " &
                    "</soapenv:Header> " &
                    "<soapenv:Body> " &
                    "<ser:sendSummary> " &
                    "<fileName>" & NomFichierZIP & "</fileName> " &
                    "<contentFile>" & Convert.ToBase64String(data) & "</contentFile> " &
                    "</ser:sendSummary> " &
                    "</soapenv:Body> " &
                    "</soapenv:Envelope>"


            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object

            strPostData = strSOAP
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "application/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("mensaje", "ERROR AL ENVIAR A LA SUNAT")
                MsgBox("Error al Enviar el Xml a la Sunat", MsgBoxStyle.Exclamation, "Service Sunat")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultcode").InnerText.Replace("soap-env:Client.", ""))
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//faultstring").InnerText)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", hash_cpe)
            Else
                ticket = doc.SelectSingleNode("//ticket").InnerText
                '========================asignamos valores de retorno======================
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "1")
                dictionary.Add("mensaje", "COMPROBANTE ENVIADO CORRECTAMENTE")
                'MsgBox("COMPROBANTE ENVIADO CORRECTAMENTE a la Sunat", MsgBoxStyle.Exclamation, "Service Sunat")
                'MsgBox("Error al Enviar el Resumen a la Sunat:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Enviando Resumen a la Sunat ..")

                dictionary.Add("cod_sunat", "")
                dictionary.Add("msj_sunat", ticket)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", hash_cpe)
                '=============eliminas el archivo comprimido que enviamos===============
                File.Delete(rutaCompleta & ".ZIP")
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working
        Catch ex As Exception
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", hash_cpe)
        End Try
        Return dictionary
    End Function

    Public Function ConsultaTicket(ruc As String, usu_sol As String, contra_sol As String, nombre_archivo As String, rutaArchivo As String, url As String, hash_cdr As String, ticket As String) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim strCDR As String
            Dim strSOAP As String
            'Dim rutaCompleta As String = rutaArchivo & nombre_archivo
            'Comprimir(nombre_archivo, rutaArchivo)
            Dim rutaCdr As String = rutaArchivo & "R-" & nombre_archivo & ".ZIP"
            'Dim NomFichierZIP As String = System.IO.Path.GetFileName(rutaCompleta & ".ZIP")
            'Dim data As Byte() = System.IO.File.ReadAllBytes(rutaCompleta & ".ZIP")

            strSOAP = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' " &
                    "xmlns:ser='http://service.sunat.gob.pe' " &
                    "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'> " &
                    "<soapenv:Header> " &
                    "<wsse:Security> " &
                    "<wsse:UsernameToken> " &
                    "<wsse:Username>" & ruc & usu_sol & "</wsse:Username> " &
                    "<wsse:Password>" & contra_sol & "</wsse:Password> " &
                    "</wsse:UsernameToken> " &
                    "</wsse:Security> " &
                    "</soapenv:Header> " &
                    "<soapenv:Body> " &
                    "<ser:getStatus> " &
                    "<ticket>" & ticket & "</ticket> " &
                    "</ser:getStatus>" &
                    "</soapenv:Body> " &
                    "</soapenv:Envelope>"


            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object

            strPostData = strSOAP
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "application/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("mensaje", "ERROR AL ENVIAR A LA SUNAT")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultcode").InnerText.Replace("soap-env:Client.", ""))
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//faultstring").InnerText)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", "")
            Else
                Dim statuCode As String

                statuCode = doc.SelectSingleNode("//statusCode").InnerText
                If statuCode = "0" Or statuCode = "99" Then
                    strCDR = doc.SelectSingleNode("//content").InnerText
                    Dim byteCDR As Byte() = Convert.FromBase64String(strCDR)
                    Dim s As IO.FileStream
                    s = IO.File.Open(rutaCdr, IO.FileMode.Append)
                    s.Write(byteCDR, 0, byteCDR.Length)
                    s.Close()

                    '===============descomprimo el xml=============
                    Descomprimir(rutaArchivo, "R-" & nombre_archivo) ''una baja de factura
                    '================================================================
                    Dim xmlCDR As New XmlDocument()
                    Dim rutaxmlCDR = rutaArchivo & "R-" & nombre_archivo & ".XML"
                    xmlCDR.Load(rutaxmlCDR)

                    '=======================nombre de espacios para obtener los valores del xml======================
                    Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                    nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    Dim nsmgrSing As New XmlNamespaceManager(doc.NameTable)
                    nsmgrSing.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

                    '========================asignamos valores de retorno======================
                    dictionary = New Dictionary(Of String, String)
                    dictionary.Add("flg_rta", "1")
                    dictionary.Add("mensaje", "COMPROBANTE ENVIADO CORRECTAMENTE")
                    dictionary.Add("cod_sunat", xmlCDR.SelectSingleNode("//cbc:ResponseCode", nsmgr).InnerText)
                    dictionary.Add("msj_sunat", xmlCDR.SelectSingleNode("//cbc:Description", nsmgr).InnerText.ToUpper)
                    dictionary.Add("hash_cdr", xmlCDR.SelectSingleNode("//ds:DigestValue", nsmgrSing).InnerText)
                    dictionary.Add("hash_cpe", "")
                    'File.Delete(rutaCompleta & ".ZIP")
                Else
                    dictionary = New Dictionary(Of String, String)
                    dictionary.Add("flg_rta", "0")
                    dictionary.Add("mensaje", "ERROR AL CONSULTAR TICKET")
                    dictionary.Add("cod_sunat", doc.SelectSingleNode("//statusCode").InnerText)
                    dictionary.Add("msj_sunat", doc.SelectSingleNode("//content").InnerText.ToUpper)
                    dictionary.Add("hash_cdr", "")
                    dictionary.Add("hash_cpe", "")
                End If
                '=============eliminas el archivo comprimido que enviamos===============
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working
        Catch ex As Exception
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            MsgBox("Error al Consultar Ticket:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Respuesta de la Sunat")
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", "")
        End Try
        Return dictionary
    End Function

    Public Function getStatusCDR(ruc As String,
                                 usu_sol As String,
                                 contra_sol As String,
                                 nombre_archivo As String,
                                 rutaArchivo As String,
                                 url As String,
                                 ruc_emisor As String,
                                 tipo_comprobante As String,
                                 serie As String,
                                 numero As String
                                 ) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim strCDR As String
            Dim strSOAP As String
            'Dim rutaCompleta As String = rutaArchivo & nombre_archivo
            'Comprimir(nombre_archivo, rutaArchivo)
            Dim rutaCdr As String = rutaArchivo & "R-" & nombre_archivo & ".ZIP"
            'Dim NomFichierZIP As String = System.IO.Path.GetFileName(rutaCompleta & ".ZIP")
            'Dim data As Byte() = System.IO.File.ReadAllBytes(rutaCompleta & ".ZIP")

            'strSOAP = "<SOAP-ENV:Envelope" & Chr(13)
            'strSOAP = strSOAP & "xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'" &
            '            "xmlns:SOAP-ENC='http://schemas.xmlsoap.org/soap/encoding/'" &
            '            "xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" &
            '            "xmlns:xsd='http://www.w3.org/2001/XMLSchema'" &
            '            "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>" &
            '            "<SOAP-ENV:Header" &
            '                "xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope'>" &
            '                "<wsse:Security>" &
            '                    "<wsse:UsernameToken>" &
            '                        "<wsse:Username>" & ruc & usu_sol & "</wsse:Username>" &
            '                        "<wsse:Password>" & contra_sol & "</wsse:Password>" &
            '                    "</wsse:UsernameToken>" &
            '                "</wsse:Security>" &
            '            "</SOAP-ENV:Header>" &
            '            "<SOAP-ENV:Body>" &
            '                "<m:getStatusCdr" &
            '                    "xmlns:m='http://service.sunat.gob.pe'>" &
            '                    "<rucComprobante>" & ruc_emisor & "</rucComprobante>" &
            '                    "<tipoComprobante>" & tipo_comprobante & "</tipoComprobante>" &
            '                    "<serieComprobante>" & serie & "</serieComprobante>" &
            '                    "<numeroComprobante>" & numero & "</numeroComprobante>" &
            '                "</m:getStatusCdr>" &
            '            "</SOAP-ENV:Body>" &
            '        "</SOAP-ENV:Envelope>"

            strSOAP = "<SOAP-ENV:Envelope
                        xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'
                        xmlns:SOAP-ENC='http://schemas.xmlsoap.org/soap/encoding/'
                        xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
                        xmlns:xsd='http://www.w3.org/2001/XMLSchema'
                        xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
                        <SOAP-ENV:Header
                            xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope'>
                            <wsse:Security>
                                <wsse:UsernameToken>
                                    <wsse:Username>" & ruc & usu_sol & "</wsse:Username>
                                    <wsse:Password>" & contra_sol & "</wsse:Password>
                                </wsse:UsernameToken>
                            </wsse:Security>
                        </SOAP-ENV:Header>
                        <SOAP-ENV:Body>
                            <m:getStatusCdr
                                xmlns:m='http://service.sunat.gob.pe'>
                                <rucComprobante>" & ruc_emisor & "</rucComprobante>
                                <tipoComprobante>" & tipo_comprobante & "</tipoComprobante>
                                <serieComprobante>" & serie & "</serieComprobante>
                                <numeroComprobante>" & numero & "</numeroComprobante>
                            </m:getStatusCdr>
                        </SOAP-ENV:Body>
                    </SOAP-ENV:Envelope>"



            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object

            strPostData = PrettyXML(strSOAP)
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "text/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("mensaje", "Error AL ENVIAR A LA SUNAT")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultcode").InnerText.Replace("ns0:", ""))
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//faultstring").InnerText)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", "")
            Else
                Dim statuCode As String

                statuCode = doc.SelectSingleNode("//statusCode").InnerText
                If statuCode = "0004" Then
                    strCDR = doc.SelectSingleNode("//content").InnerText
                    Dim byteCDR As Byte() = Convert.FromBase64String(strCDR)
                    Dim s As IO.FileStream
                    s = IO.File.Open(rutaCdr, IO.FileMode.Append)
                    s.Write(byteCDR, 0, byteCDR.Length)
                    s.Close()

                    '===============descomprimo el xml=============
                    Descomprimir(rutaArchivo, "R-" & nombre_archivo)
                    '================================================================
                    Dim xmlCDR As New XmlDocument()
                    Dim rutaxmlCDR = rutaArchivo & "R-" & nombre_archivo & ".XML"
                    xmlCDR.Load(rutaxmlCDR)

                    '=======================nombre de espacios para obtener los valores del xml======================
                    Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
                    nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                    Dim nsmgrSing As New XmlNamespaceManager(doc.NameTable)
                    nsmgrSing.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

                    '========================asignamos valores de retorno======================
                    dictionary = New Dictionary(Of String, String)
                    dictionary.Add("flg_rta", "1")
                    dictionary.Add("mensaje", "COMPROBANTE ENVIADO CORRECTAMENTE")
                    dictionary.Add("cod_sunat", xmlCDR.SelectSingleNode("//cbc:ResponseCode", nsmgr).InnerText)
                    dictionary.Add("msj_sunat", xmlCDR.SelectSingleNode("//cbc:Description", nsmgr).InnerText.ToUpper)
                    dictionary.Add("hash_cdr", xmlCDR.SelectSingleNode("//ds:DigestValue", nsmgrSing).InnerText)
                    dictionary.Add("hash_cpe", "")
                    'File.Delete(rutaCompleta & ".ZIP")
                Else
                    dictionary = New Dictionary(Of String, String)
                    dictionary.Add("flg_rta", "0")
                    dictionary.Add("mensaje", "ERROR AL CONSULTAR STATUS CDR")
                    dictionary.Add("cod_sunat", doc.SelectSingleNode("//statusCode").InnerText)
                    dictionary.Add("msj_sunat", doc.SelectSingleNode("//statusMessage").InnerText.ToUpper)
                    dictionary.Add("hash_cdr", "")
                    dictionary.Add("hash_cpe", "")
                End If
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working
        Catch ex As Exception
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", "")
        End Try
        Return dictionary
    End Function

    Public Function getStatusFactura(ruc As String,
                                     usu_sol As String,
                                     contra_sol As String,
                                     url As String,
                                     ruc_emisor As String,
                                     tipo_comprobante As String,
                                     serie As String,
                                     numero As String
                                 ) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Try
            Dim doc As New XmlDocument()
            Dim strSOAP As String

            strSOAP = "<soapenv:Envelope xmlns:ser='http://service.sunat.gob.pe' " &
                        "xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' " &
                        "xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'> " &
                        "<soapenv:Header> " &
                        "<wsse:Security> " &
                        "<wsse:UsernameToken> " &
                        "<wsse:Username>" & ruc & usu_sol & "</wsse:Username> " &
                        "<wsse:Password>" & contra_sol & "</wsse:Password> " &
                        "</wsse:UsernameToken> " &
                        "</wsse:Security> " &
                        "</soapenv:Header> " &
                        "<soapenv:Body> " &
                        "<ser:getStatus> " &
                        "<rucComprobante>" & ruc_emisor & "</rucComprobante> " &
                        "<tipoComprobante>" & tipo_comprobante & "</tipoComprobante> " &
                        "<serieComprobante>" & serie & "</serieComprobante> " &
                        "<numeroComprobante>" & numero & "</numeroComprobante> " &
                        "</ser:getStatus> " &
                        "</soapenv:Body> " &
                        "</soapenv:Envelope>"

            'strSOAP = "<soapenv:Envelope xmlns:ser='http://service.sunat.gob.pe'
            '        xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'
            '        xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
            '            <soapenv:Header>
            '                <wsse:Security>
            '                    <wsse:UsernameToken>
            '                        <wsse:Username>20100066603MODDATOS</wsse:Username>
            '                        <wsse:Password>moddatos</wsse:Password>
            '                    </wsse:UsernameToken>
            '                </wsse:Security>
            '            </soapenv:Header>
            '           <soapenv:Body>
            '              <ser:getStatus>
            '                  <rucComprobante>1028308796</rucComprobante>
            '                  <tipoComprobante>01</tipoComprobante>
            '                  <serieComprobante>F213</serieComprobante>
            '                  <numeroComprobante>12345</numeroComprobante>
            '              </ser:getStatus>
            '           </soapenv:Body>
            '        </soapenv:Envelope>"



            Dim returned_value As String
            Dim strPostData As String
            Dim objRequest As Object

            strPostData = strSOAP
            'objRequest = CreateObject("MSXML2.XMLHTTP.3.0")
            objRequest = CreateObject("MSXML2.ServerXMLHTTP")
            With objRequest
                .Open("POST", url, False)
                .setRequestHeader("Content-Type", "text/xml")
                .send(strPostData)
                returned_value = .responseText
            End With
            doc.LoadXml(returned_value)

            '=======================validando respuesta========================
            Dim Lst As XmlNodeList = doc.SelectNodes("//faultcode")
            If Lst.Count() > 0 Then
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "0")
                dictionary.Add("mensaje", "ERROR AL CONSULTAR EN LA SUNAT")
                dictionary.Add("cod_sunat", doc.SelectSingleNode("//faultcode").InnerText.Replace("ns0:", ""))
                dictionary.Add("msj_sunat", doc.SelectSingleNode("//faultstring").InnerText)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", "")
            Else
                Dim statuCode As String
                Dim statuMensaje As String

                statuCode = doc.SelectSingleNode("//statusCode").InnerText
                statuMensaje = doc.SelectSingleNode("//statusMessage").InnerText

                '========================asignamos valores de retorno======================
                dictionary = New Dictionary(Of String, String)
                dictionary.Add("flg_rta", "1")
                dictionary.Add("mensaje", "COMPROBANTE CONSULTADO CORRECTAMENTE")
                dictionary.Add("cod_sunat", statuCode)
                dictionary.Add("msj_sunat", statuMensaje)
                dictionary.Add("hash_cdr", "")
                dictionary.Add("hash_cpe", "")
            End If

            'https://stackoverflow.com/questions/16889895/c-sharp-xmldocument-selectnodes-is-not-working
        Catch ex As Exception
            dictionary = New Dictionary(Of String, String)
            dictionary.Add("flg_rta", "0")
            dictionary.Add("mensaje", "ERROR AL CONECTARSE A LA SUNAT: " & ex.Message)
            dictionary.Add("cod_sunat", "")
            dictionary.Add("msj_sunat", "")
            dictionary.Add("hash_cdr", "")
            dictionary.Add("hash_cpe", "")
        End Try
        Return dictionary
    End Function


End Class
