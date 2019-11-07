// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.MobilpayEncryptDecrypt
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using JavaScience;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  public class MobilpayEncryptDecrypt
  {
    public int BuildXmlEncrypt(Mobilpay_Payment_Request_Card card, MobilpayEncrypt mobilpayEncrypt)
    {
      try
      {
        string message = this.VerifyCardObject(card);
        if (message == "")
        {
          string xmlText = this.GetXmlText(card);          
          mobilpayEncrypt.Data = xmlText;
          Encrypt(mobilpayEncrypt);
          return 0;
        }
        Exception exception = new Exception(message);
        return -1;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public Mobilpay_Payment_Request_Card BuildCardDecrypt(
      MobilpayDecrypt mobilpayDecrypt)
    {
      try
      {
        Mobilpay_Payment_Request_Card paymentRequestCard = new Mobilpay_Payment_Request_Card();
        if (Decrypt(mobilpayDecrypt) == 0)
          return this.GetCard(mobilpayDecrypt.DecryptedData);
        Exception exception = new Exception("0x300000f3");
        return (Mobilpay_Payment_Request_Card) null;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int Encrypt(MobilpayEncrypt mobilpayEncrypt)
    {
      try
      {
        byte[] bytes = Encoding.ASCII.GetBytes(mobilpayEncrypt.Data);
        Random random = new Random();
        byte[] numArray = new byte[8];
        for (int index = 0; index < numArray.Length; ++index)
          numArray[index] = (byte) random.Next(0, (int) byte.MaxValue);
        this.RC4(ref bytes, numArray);
        var publicKey = new X509Certificate2(mobilpayEncrypt.X509CertificateFilePath).GetRSAPublicKey();
        //RSACng key = (RSACryptoServiceProvider)publicKey;
        publicKey.ExportParameters(false);
        byte[] inArray = publicKey.Encrypt(numArray, RSAEncryptionPadding.Pkcs1);
        mobilpayEncrypt.EncryptedData = Convert.ToBase64String(bytes);
        mobilpayEncrypt.EnvelopeKey = Convert.ToBase64String(inArray);
      }
      catch (CryptographicException ex)
      {
        throw ex;
      }
      return 0;
    }

    public int Decrypt(MobilpayDecrypt mobilpayDecrypt)
    {
      try
      {
        StreamReader streamReader = File.OpenText(mobilpayDecrypt.PrivateKeyFilePath);
        string sPrivKey = streamReader.ReadToEnd().Trim();
        streamReader.Close();
        RSACryptoServiceProvider decodedPrivKeyInfo = opensslkey.GetDecodedPrivKeyInfo(sPrivKey);
        byte[] rgb = Convert.FromBase64String(mobilpayDecrypt.EnvelopeKey);
        byte[] bytes = Convert.FromBase64String(mobilpayDecrypt.Data);
        try
        {
          byte[] key = decodedPrivKeyInfo.Decrypt(rgb, false);
          this.RC4(ref bytes, key);
          mobilpayDecrypt.DecryptedData = Encoding.ASCII.GetString(bytes);
        }
        catch (CryptographicException ex)
        {
          throw ex;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return 0;
    }

    private void RC4(ref byte[] bytes, byte[] key)
    {
      byte[] numArray1 = new byte[256];
      byte[] numArray2 = new byte[256];
      for (int index = 0; index < 256; ++index)
      {
        numArray1[index] = (byte) index;
        numArray2[index] = key[index % key.GetLength(0)];
      }
      int index1 = 0;
      for (int index2 = 0; index2 < 256; ++index2)
      {
        index1 = (index1 + (int) numArray1[index2] + (int) numArray2[index2]) % 256;
        byte num = numArray1[index2];
        numArray1[index2] = numArray1[index1];
        numArray1[index1] = num;
      }
      int index3;
      int index4 = index3 = 0;
      for (int index2 = 0; index2 < bytes.GetLength(0); ++index2)
      {
        index4 = (index4 + 1) % 256;
        index3 = (index3 + (int) numArray1[index4]) % 256;
        byte num = numArray1[index4];
        numArray1[index4] = numArray1[index3];
        numArray1[index3] = num;
        int index5 = ((int) numArray1[index4] + (int) numArray1[index3]) % 256;
        bytes[index2] ^= numArray1[index5];
      }
    }

    public string MD5PHP(string password)
    {
      byte[] bytes = Encoding.Default.GetBytes(password);
      try
      {
        byte[] hash = new MD5CryptoServiceProvider().ComputeHash(bytes);
        string str = "";
        foreach (byte num in hash)
          str = num >= (byte) 16 ? str + num.ToString("x") : str + "0" + num.ToString("x");
        return str;
      }
      catch
      {
        throw;
      }
    }

    private string VerifyCardObject(Mobilpay_Payment_Request_Card card)
    {
      if (card.Type == "" || card.Type == null)
        return "type is mandatory";
      if (card.OrderId == "" || card.OrderId == null)
        return "id is mandatory";
      if (card.Signature == "" || card.Signature == null)
        return "signature is mandatory";
      if (card.Invoice == null)
        return "amount is mandatory";
      if (card.Invoice.Amount == new Decimal(0))
        return "amonut is mandatory";
      return card.Invoice.Currency == "" || card.Invoice.Currency == null ? "currency is mandatory" : "";
    }

    public string GetXmlText(Mobilpay_Payment_Request_Card card)
    {
      try
      {
        string message = this.VerifyCardObject(card);
        if (!(this.VerifyCardObject(card) == ""))
          throw new Exception(message);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (Mobilpay_Payment_Request_Card));
        Stream stream = (Stream) new MemoryStream();
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        xmlSerializer.Serialize(stream, (object) card, namespaces);
        stream.Position = 0L;
        return new StreamReader(stream).ReadToEnd();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public string GetXmlText(Mobilpay_Payment_Request_Sms sms)
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (Mobilpay_Payment_Request_Sms));
        Stream stream = (Stream) new MemoryStream();
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        xmlSerializer.Serialize(stream, (object) sms, namespaces);
        stream.Position = 0L;
        return new StreamReader(stream).ReadToEnd();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public Mobilpay_Payment_Request_Card GetCard(string text)
    {
      try
      {
        byte[] bytes = Encoding.ASCII.GetBytes(text);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (Mobilpay_Payment_Request_Card));
        Stream stream = (Stream) new MemoryStream(bytes);
        XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
        return (Mobilpay_Payment_Request_Card) xmlSerializer.Deserialize(stream);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public Mobilpay_Payment_Request_Sms GetSms(string text)
    {
      try
      {
        byte[] bytes = Encoding.ASCII.GetBytes(text);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (Mobilpay_Payment_Request_Sms));
        Stream stream = (Stream) new MemoryStream(bytes);
        XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
        return (Mobilpay_Payment_Request_Sms) xmlSerializer.Deserialize(stream);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
