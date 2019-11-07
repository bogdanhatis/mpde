// Decompiled with JetBrains decompiler
// Type: JavaScience.opensslkey
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JavaScience
{
  public class opensslkey
  {
    private const string pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
    private const string pemprivfooter = "-----END RSA PRIVATE KEY-----";
    private const string pempubheader = "-----BEGIN PUBLIC KEY-----";
    private const string pempubfooter = "-----END PUBLIC KEY-----";
    private const string pemp8header = "-----BEGIN PRIVATE KEY-----";
    private const string pemp8footer = "-----END PRIVATE KEY-----";
    private const string pemp8encheader = "-----BEGIN ENCRYPTED PRIVATE KEY-----";
    private const string pemp8encfooter = "-----END ENCRYPTED PRIVATE KEY-----";
    private static bool verbose;

    public static void DecodePEMKey(string pemstr)
    {
      if (pemstr.StartsWith("-----BEGIN PUBLIC KEY-----") && pemstr.EndsWith("-----END PUBLIC KEY-----"))
      {
        Console.WriteLine("Trying to decode and parse a PEM public key ..");
        byte[] numArray = opensslkey.DecodeOpenSSLPublicKey(pemstr);
        if (numArray == null)
          return;
        if (opensslkey.verbose)
          opensslkey.showBytes("\nRSA public key", numArray);
        RSACryptoServiceProvider cryptoServiceProvider = opensslkey.DecodeX509PublicKey(numArray);
        Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
        string xmlString = cryptoServiceProvider.ToXmlString(false);
        Console.WriteLine("\nXML RSA public key:  {0} bits\n{1}\n", (object) cryptoServiceProvider.KeySize, (object) xmlString);
      }
      else if (pemstr.StartsWith("-----BEGIN RSA PRIVATE KEY-----") && pemstr.EndsWith("-----END RSA PRIVATE KEY-----"))
      {
        Console.WriteLine("Trying to decrypt and parse a PEM private key ..");
        byte[] numArray = opensslkey.DecodeOpenSSLPrivateKey(pemstr);
        if (numArray == null)
          return;
        if (opensslkey.verbose)
          opensslkey.showBytes("\nRSA private key", numArray);
        RSACryptoServiceProvider rsa = opensslkey.DecodeRSAPrivateKey(numArray);
        Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
        string xmlString = rsa.ToXmlString(true);
        Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa.KeySize, (object) xmlString);
        opensslkey.ProcessRSA(rsa);
      }
      else if (pemstr.StartsWith("-----BEGIN PRIVATE KEY-----") && pemstr.EndsWith("-----END PRIVATE KEY-----"))
      {
        Console.WriteLine("Trying to decode and parse as PEM PKCS #8 PrivateKeyInfo ..");
        byte[] numArray = opensslkey.DecodePkcs8PrivateKey(pemstr);
        if (numArray == null)
          return;
        if (opensslkey.verbose)
          opensslkey.showBytes("\nPKCS #8 PrivateKeyInfo", numArray);
        RSACryptoServiceProvider rsa = opensslkey.DecodePrivateKeyInfo(numArray);
        if (rsa != null)
        {
          Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
          string xmlString = rsa.ToXmlString(true);
          Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa.KeySize, (object) xmlString);
          opensslkey.ProcessRSA(rsa);
        }
        else
          Console.WriteLine("\nFailed to create an RSACryptoServiceProvider");
      }
      else if (pemstr.StartsWith("-----BEGIN ENCRYPTED PRIVATE KEY-----") && pemstr.EndsWith("-----END ENCRYPTED PRIVATE KEY-----"))
      {
        Console.WriteLine("Trying to decode and parse as PEM PKCS #8 EncryptedPrivateKeyInfo ..");
        byte[] numArray = opensslkey.DecodePkcs8EncPrivateKey(pemstr);
        if (numArray == null)
          return;
        if (opensslkey.verbose)
          opensslkey.showBytes("\nPKCS #8 EncryptedPrivateKeyInfo", numArray);
        RSACryptoServiceProvider rsa = opensslkey.DecodeEncryptedPrivateKeyInfo(numArray);
        if (rsa != null)
        {
          Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
          string xmlString = rsa.ToXmlString(true);
          Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa.KeySize, (object) xmlString);
          opensslkey.ProcessRSA(rsa);
        }
        else
          Console.WriteLine("\nFailed to create an RSACryptoServiceProvider");
      }
      else
        Console.WriteLine("Not a PEM public, private key or a PKCS #8");
    }

    public static void DecodeDERKey(string filename)
    {
      byte[] fileBytes = opensslkey.GetFileBytes(filename);
      if (fileBytes == null)
        return;
      RSACryptoServiceProvider cryptoServiceProvider = opensslkey.DecodeX509PublicKey(fileBytes);
      if (cryptoServiceProvider != null)
      {
        Console.WriteLine("\nA valid SubjectPublicKeyInfo\n");
        Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
        string xmlString = cryptoServiceProvider.ToXmlString(false);
        Console.WriteLine("\nXML RSA public key:  {0} bits\n{1}\n", (object) cryptoServiceProvider.KeySize, (object) xmlString);
      }
      else
      {
        RSACryptoServiceProvider rsa1 = opensslkey.DecodeRSAPrivateKey(fileBytes);
        if (rsa1 != null)
        {
          Console.WriteLine("\nA valid RSAPrivateKey\n");
          Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
          string xmlString = rsa1.ToXmlString(true);
          Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa1.KeySize, (object) xmlString);
          opensslkey.ProcessRSA(rsa1);
        }
        else
        {
          RSACryptoServiceProvider rsa2 = opensslkey.DecodePrivateKeyInfo(fileBytes);
          if (rsa2 != null)
          {
            Console.WriteLine("\nA valid PKCS #8 PrivateKeyInfo\n");
            Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
            string xmlString = rsa2.ToXmlString(true);
            Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa2.KeySize, (object) xmlString);
            opensslkey.ProcessRSA(rsa2);
          }
          else
          {
            RSACryptoServiceProvider rsa3 = opensslkey.DecodeEncryptedPrivateKeyInfo(fileBytes);
            if (rsa3 != null)
            {
              Console.WriteLine("\nA valid PKCS #8 EncryptedPrivateKeyInfo\n");
              Console.WriteLine("\nCreated an RSACryptoServiceProvider instance\n");
              string xmlString = rsa3.ToXmlString(true);
              Console.WriteLine("\nXML RSA private key:  {0} bits\n{1}\n", (object) rsa3.KeySize, (object) xmlString);
              opensslkey.ProcessRSA(rsa3);
            }
            else
              Console.WriteLine("Not a binary DER public, private or PKCS #8 key");
          }
        }
      }
    }

    public static RSACryptoServiceProvider GetDecodedPrivKeyInfo(
      string sPrivKey)
    {
      if (sPrivKey.StartsWith("-----BEGIN RSA PRIVATE KEY-----") && sPrivKey.EndsWith("-----END RSA PRIVATE KEY-----"))
        return opensslkey.DecodeRSAPrivateKey(opensslkey.DecodeOpenSSLPrivateKey(sPrivKey));
      if (sPrivKey.StartsWith("-----BEGIN PRIVATE KEY-----") && sPrivKey.EndsWith("-----END PRIVATE KEY-----"))
        return opensslkey.DecodePrivateKeyInfo(opensslkey.DecodePkcs8PrivateKey(sPrivKey));
      if (sPrivKey.StartsWith("-----BEGIN ENCRYPTED PRIVATE KEY-----") && sPrivKey.EndsWith("-----END ENCRYPTED PRIVATE KEY-----"))
        return opensslkey.DecodeEncryptedPrivateKeyInfo(opensslkey.DecodePkcs8EncPrivateKey(sPrivKey));
      return (RSACryptoServiceProvider) null;
    }

    public static void ProcessRSA(RSACryptoServiceProvider rsa)
    {
      if (opensslkey.verbose)
        opensslkey.showRSAProps(rsa);
      Console.Write("\n\nExport RSA private key to PKCS #12 file?  (Y or N) ");
      string upper = Console.ReadLine().ToUpper();
      if (!(upper == "Y") && !(upper == "YES"))
        return;
      opensslkey.RSAtoPKCS12(rsa);
    }

    public static void RSAtoPKCS12(RSACryptoServiceProvider rsa)
    {
      CspKeyContainerInfo keyContainerInfo = rsa.CspKeyContainerInfo;
      string keyContainerName = keyContainerInfo.KeyContainerName;
      uint keyNumber = (uint) keyContainerInfo.KeyNumber;
      string providerName = keyContainerInfo.ProviderName;
      uint cspflags = 0;
      string outfile = keyContainerName + ".p12";
      byte[] pkcs12 = opensslkey.GetPkcs12((RSA) rsa, keyContainerName, providerName, keyNumber, cspflags);
      if (pkcs12 != null && opensslkey.verbose)
        opensslkey.showBytes("\npkcs #12", pkcs12);
      if (pkcs12 != null)
      {
        opensslkey.PutFileBytes(outfile, pkcs12, pkcs12.Length);
        Console.WriteLine("\nWrote pkc #12 file '{0}'\n", (object) outfile);
      }
      else
        Console.WriteLine("\nProblem getting pkcs#12");
    }

    public static byte[] DecodePkcs8PrivateKey(string instr)
    {
      string str = instr.Trim();
      if (!str.StartsWith("-----BEGIN PRIVATE KEY-----") || !str.EndsWith("-----END PRIVATE KEY-----"))
        return (byte[]) null;
      StringBuilder stringBuilder = new StringBuilder(str);
      stringBuilder.Replace("-----BEGIN PRIVATE KEY-----", "");
      stringBuilder.Replace("-----END PRIVATE KEY-----", "");
      string s = stringBuilder.ToString().Trim();
      try
      {
        return Convert.FromBase64String(s);
      }
      catch (FormatException ex)
      {
        return (byte[]) null;
      }
    }

    public static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
    {
      byte[] b = new byte[15]
      {
        (byte) 48,
        (byte) 13,
        (byte) 6,
        (byte) 9,
        (byte) 42,
        (byte) 134,
        (byte) 72,
        (byte) 134,
        (byte) 247,
        (byte) 13,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 5,
        (byte) 0
      };
      byte[] numArray = new byte[15];
      MemoryStream memoryStream = new MemoryStream(pkcs8);
      int length = (int) memoryStream.Length;
      BinaryReader binaryReader = new BinaryReader((Stream) memoryStream);
      try
      {
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num1 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num2 = (int) binaryReader.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        if (binaryReader.ReadByte() != (byte) 2 || binaryReader.ReadUInt16() != (ushort) 1 || (!opensslkey.CompareBytearrays(binaryReader.ReadBytes(15), b) || binaryReader.ReadByte() != (byte) 4))
          return (RSACryptoServiceProvider) null;
        switch (binaryReader.ReadByte())
        {
          case 129:
            int num3 = (int) binaryReader.ReadByte();
            break;
          case 130:
            int num4 = (int) binaryReader.ReadUInt16();
            break;
        }
        return opensslkey.DecodeRSAPrivateKey(binaryReader.ReadBytes((int) ((long) length - memoryStream.Position)));
      }
      catch (Exception ex)
      {
        return (RSACryptoServiceProvider) null;
      }
      finally
      {
        binaryReader.Close();
      }
    }

    public static byte[] DecodePkcs8EncPrivateKey(string instr)
    {
      string str = instr.Trim();
      if (!str.StartsWith("-----BEGIN ENCRYPTED PRIVATE KEY-----") || !str.EndsWith("-----END ENCRYPTED PRIVATE KEY-----"))
        return (byte[]) null;
      StringBuilder stringBuilder = new StringBuilder(str);
      stringBuilder.Replace("-----BEGIN ENCRYPTED PRIVATE KEY-----", "");
      stringBuilder.Replace("-----END ENCRYPTED PRIVATE KEY-----", "");
      string s = stringBuilder.ToString().Trim();
      try
      {
        return Convert.FromBase64String(s);
      }
      catch (FormatException ex)
      {
        return (byte[]) null;
      }
    }

    public static RSACryptoServiceProvider DecodeEncryptedPrivateKeyInfo(
      byte[] encpkcs8)
    {
      byte[] b1 = new byte[11]
      {
        (byte) 6,
        (byte) 9,
        (byte) 42,
        (byte) 134,
        (byte) 72,
        (byte) 134,
        (byte) 247,
        (byte) 13,
        (byte) 1,
        (byte) 5,
        (byte) 13
      };
      byte[] b2 = new byte[11]
      {
        (byte) 6,
        (byte) 9,
        (byte) 42,
        (byte) 134,
        (byte) 72,
        (byte) 134,
        (byte) 247,
        (byte) 13,
        (byte) 1,
        (byte) 5,
        (byte) 12
      };
      byte[] b3 = new byte[10]
      {
        (byte) 6,
        (byte) 8,
        (byte) 42,
        (byte) 134,
        (byte) 72,
        (byte) 134,
        (byte) 247,
        (byte) 13,
        (byte) 3,
        (byte) 7
      };
      byte[] numArray1 = new byte[10];
      byte[] numArray2 = new byte[11];
      MemoryStream memoryStream = new MemoryStream(encpkcs8);
      long length = memoryStream.Length;
      BinaryReader binaryReader = new BinaryReader((Stream) memoryStream);
      try
      {
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num1 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num2 = (int) binaryReader.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num3 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num4 = (int) binaryReader.ReadInt16();
            break;
        }
        if (!opensslkey.CompareBytearrays(binaryReader.ReadBytes(11), b1))
          return (RSACryptoServiceProvider) null;
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num5 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num6 = (int) binaryReader.ReadInt16();
            break;
        }
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num7 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num8 = (int) binaryReader.ReadInt16();
            break;
        }
        if (!opensslkey.CompareBytearrays(binaryReader.ReadBytes(11), b2))
          return (RSACryptoServiceProvider) null;
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num9 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num10 = (int) binaryReader.ReadInt16();
            break;
        }
        if (binaryReader.ReadByte() != (byte) 4)
          return (RSACryptoServiceProvider) null;
        int count1 = (int) binaryReader.ReadByte();
        byte[] numArray3 = binaryReader.ReadBytes(count1);
        if (opensslkey.verbose)
          opensslkey.showBytes("Salt for pbkd", numArray3);
        if (binaryReader.ReadByte() != (byte) 2)
          return (RSACryptoServiceProvider) null;
        int iterations;
        switch (binaryReader.ReadByte())
        {
          case 1:
            iterations = (int) binaryReader.ReadByte();
            break;
          case 2:
            iterations = 256 * (int) binaryReader.ReadByte() + (int) binaryReader.ReadByte();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        if (opensslkey.verbose)
          Console.WriteLine("PBKD2 iterations {0}", (object) iterations);
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num11 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num12 = (int) binaryReader.ReadInt16();
            break;
        }
        if (!opensslkey.CompareBytearrays(binaryReader.ReadBytes(10), b3) || binaryReader.ReadByte() != (byte) 4)
          return (RSACryptoServiceProvider) null;
        int count2 = (int) binaryReader.ReadByte();
        byte[] numArray4 = binaryReader.ReadBytes(count2);
        if (opensslkey.verbose)
          opensslkey.showBytes("IV for des-EDE3-CBC", numArray4);
        if (binaryReader.ReadByte() != (byte) 4)
          return (RSACryptoServiceProvider) null;
        byte num13 = binaryReader.ReadByte();
        int count3;
        switch (num13)
        {
          case 129:
            count3 = (int) binaryReader.ReadByte();
            break;
          case 130:
            count3 = 256 * (int) binaryReader.ReadByte() + (int) binaryReader.ReadByte();
            break;
          default:
            count3 = (int) num13;
            break;
        }
        byte[] edata = binaryReader.ReadBytes(count3);
        SecureString secPswd = opensslkey.GetSecPswd("Enter password for Encrypted PKCS #8 ==>");
        byte[] pkcs8 = opensslkey.DecryptPBDK2(edata, numArray3, numArray4, secPswd, iterations);
        if (pkcs8 == null)
          return (RSACryptoServiceProvider) null;
        return opensslkey.DecodePrivateKeyInfo(pkcs8);
      }
      catch (Exception ex)
      {
        return (RSACryptoServiceProvider) null;
      }
      finally
      {
        binaryReader.Close();
      }
    }

    public static byte[] DecryptPBDK2(
      byte[] edata,
      byte[] salt,
      byte[] IV,
      SecureString secpswd,
      int iterations)
    {
      IntPtr zero = IntPtr.Zero;
      byte[] numArray = new byte[secpswd.Length];
      IntPtr globalAllocAnsi = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
      Marshal.Copy(globalAllocAnsi, numArray, 0, numArray.Length);
      Marshal.ZeroFreeGlobalAllocAnsi(globalAllocAnsi);
      try
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(numArray, salt, iterations);
        TripleDES tripleDes = TripleDES.Create();
        tripleDes.Key = rfc2898DeriveBytes.GetBytes(24);
        tripleDes.IV = IV;
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(edata, 0, edata.Length);
        cryptoStream.Flush();
        cryptoStream.Close();
        return memoryStream.ToArray();
      }
      catch (Exception ex)
      {
        Console.WriteLine("Problem decrypting: {0}", (object) ex.Message);
        return (byte[]) null;
      }
    }

    public static byte[] DecodeOpenSSLPublicKey(string instr)
    {
      string str = instr.Trim();
      if (!str.StartsWith("-----BEGIN PUBLIC KEY-----") || !str.EndsWith("-----END PUBLIC KEY-----"))
        return (byte[]) null;
      StringBuilder stringBuilder = new StringBuilder(str);
      stringBuilder.Replace("-----BEGIN PUBLIC KEY-----", "");
      stringBuilder.Replace("-----END PUBLIC KEY-----", "");
      string s = stringBuilder.ToString().Trim();
      try
      {
        return Convert.FromBase64String(s);
      }
      catch (FormatException ex)
      {
        return (byte[]) null;
      }
    }

    public static RSACryptoServiceProvider DecodeX509PublicKey(
      byte[] x509key)
    {
      byte[] b = new byte[15]
      {
        (byte) 48,
        (byte) 13,
        (byte) 6,
        (byte) 9,
        (byte) 42,
        (byte) 134,
        (byte) 72,
        (byte) 134,
        (byte) 247,
        (byte) 13,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 5,
        (byte) 0
      };
      byte[] numArray = new byte[15];
      BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(x509key));
      try
      {
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num1 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num2 = (int) binaryReader.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        if (!opensslkey.CompareBytearrays(binaryReader.ReadBytes(15), b))
          return (RSACryptoServiceProvider) null;
        switch (binaryReader.ReadUInt16())
        {
          case 33027:
            int num3 = (int) binaryReader.ReadByte();
            break;
          case 33283:
            int num4 = (int) binaryReader.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        if (binaryReader.ReadByte() != (byte) 0)
          return (RSACryptoServiceProvider) null;
        switch (binaryReader.ReadUInt16())
        {
          case 33072:
            int num5 = (int) binaryReader.ReadByte();
            break;
          case 33328:
            int num6 = (int) binaryReader.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        ushort num7 = binaryReader.ReadUInt16();
        byte num8 = 0;
        byte num9;
        switch (num7)
        {
          case 33026:
            num9 = binaryReader.ReadByte();
            break;
          case 33282:
            num8 = binaryReader.ReadByte();
            num9 = binaryReader.ReadByte();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        int int32 = BitConverter.ToInt32(new byte[4]
        {
          num9,
          num8,
          (byte) 0,
          (byte) 0
        }, 0);
        byte num10 = binaryReader.ReadByte();
        binaryReader.BaseStream.Seek(-1L, SeekOrigin.Current);
        if (num10 == (byte) 0)
        {
          int num11 = (int) binaryReader.ReadByte();
          --int32;
        }
        byte[] data1 = binaryReader.ReadBytes(int32);
        if (binaryReader.ReadByte() != (byte) 2)
          return (RSACryptoServiceProvider) null;
        int count = (int) binaryReader.ReadByte();
        byte[] data2 = binaryReader.ReadBytes(count);
        opensslkey.showBytes("\nExponent", data2);
        opensslkey.showBytes("\nModulus", data1);
        RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
        cryptoServiceProvider.ImportParameters(new RSAParameters()
        {
          Modulus = data1,
          Exponent = data2
        });
        return cryptoServiceProvider;
      }
      catch (Exception ex)
      {
        return (RSACryptoServiceProvider) null;
      }
      finally
      {
        binaryReader.Close();
      }
    }

    public static RSACryptoServiceProvider DecodeRSAPrivateKey(
      byte[] privkey)
    {
      BinaryReader binr = new BinaryReader((Stream) new MemoryStream(privkey));
      try
      {
        switch (binr.ReadUInt16())
        {
          case 33072:
            int num1 = (int) binr.ReadByte();
            break;
          case 33328:
            int num2 = (int) binr.ReadInt16();
            break;
          default:
            return (RSACryptoServiceProvider) null;
        }
        if (binr.ReadUInt16() != (ushort) 258 || binr.ReadByte() != (byte) 0)
          return (RSACryptoServiceProvider) null;
        int integerSize1 = opensslkey.GetIntegerSize(binr);
        byte[] numArray1 = binr.ReadBytes(integerSize1);
        int integerSize2 = opensslkey.GetIntegerSize(binr);
        byte[] numArray2 = binr.ReadBytes(integerSize2);
        int integerSize3 = opensslkey.GetIntegerSize(binr);
        byte[] numArray3 = binr.ReadBytes(integerSize3);
        int integerSize4 = opensslkey.GetIntegerSize(binr);
        byte[] numArray4 = binr.ReadBytes(integerSize4);
        int integerSize5 = opensslkey.GetIntegerSize(binr);
        byte[] numArray5 = binr.ReadBytes(integerSize5);
        int integerSize6 = opensslkey.GetIntegerSize(binr);
        byte[] numArray6 = binr.ReadBytes(integerSize6);
        int integerSize7 = opensslkey.GetIntegerSize(binr);
        byte[] numArray7 = binr.ReadBytes(integerSize7);
        int integerSize8 = opensslkey.GetIntegerSize(binr);
        byte[] numArray8 = binr.ReadBytes(integerSize8);
        RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(new CspParameters()
        {
          Flags = CspProviderFlags.UseMachineKeyStore
        });
        cryptoServiceProvider.ImportParameters(new RSAParameters()
        {
          Modulus = numArray1,
          Exponent = numArray2,
          D = numArray3,
          P = numArray4,
          Q = numArray5,
          DP = numArray6,
          DQ = numArray7,
          InverseQ = numArray8
        });
        return cryptoServiceProvider;
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
        return (RSACryptoServiceProvider) null;
      }
      finally
      {
        binr.Close();
      }
    }

    private static int GetIntegerSize(BinaryReader binr)
    {
      if (binr.ReadByte() != (byte) 2)
        return 0;
      byte num1 = binr.ReadByte();
      int num2;
      switch (num1)
      {
        case 129:
          num2 = (int) binr.ReadByte();
          break;
        case 130:
          byte num3 = binr.ReadByte();
          num2 = BitConverter.ToInt32(new byte[4]
          {
            binr.ReadByte(),
            num3,
            (byte) 0,
            (byte) 0
          }, 0);
          break;
        default:
          num2 = (int) num1;
          break;
      }
      while (binr.ReadByte() == (byte) 0)
        --num2;
      binr.BaseStream.Seek(-1L, SeekOrigin.Current);
      return num2;
    }

    public static byte[] DecodeOpenSSLPrivateKey(string instr)
    {
      string str1 = instr.Trim();
      if (!str1.StartsWith("-----BEGIN RSA PRIVATE KEY-----") || !str1.EndsWith("-----END RSA PRIVATE KEY-----"))
        return (byte[]) null;
      StringBuilder stringBuilder = new StringBuilder(str1);
      stringBuilder.Replace("-----BEGIN RSA PRIVATE KEY-----", "");
      stringBuilder.Replace("-----END RSA PRIVATE KEY-----", "");
      string s = stringBuilder.ToString().Trim();
      try
      {
        return Convert.FromBase64String(s);
      }
      catch (FormatException ex)
      {
      }
      StringReader stringReader = new StringReader(s);
      if (!stringReader.ReadLine().StartsWith("Proc-Type: 4,ENCRYPTED"))
        return (byte[]) null;
      string str2 = stringReader.ReadLine();
      if (!str2.StartsWith("DEK-Info: DES-EDE3-CBC,"))
        return (byte[]) null;
      string str3 = str2.Substring(str2.IndexOf(",") + 1).Trim();
      byte[] numArray = new byte[str3.Length / 2];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = Convert.ToByte(str3.Substring(index * 2, 2), 16);
      if (!(stringReader.ReadLine() == ""))
        return (byte[]) null;
      string end = stringReader.ReadToEnd();
      byte[] cipherData;
      try
      {
        cipherData = Convert.FromBase64String(end);
      }
      catch (FormatException ex)
      {
        return (byte[]) null;
      }
      SecureString secPswd = opensslkey.GetSecPswd("Enter password to derive 3DES key==>");
      byte[] openSsL3deskey = opensslkey.GetOpenSSL3deskey(numArray, secPswd, 1, 2);
      if (openSsL3deskey == null)
        return (byte[]) null;
      return opensslkey.DecryptKey(cipherData, openSsL3deskey, numArray) ?? (byte[]) null;
    }

    public static byte[] DecryptKey(byte[] cipherData, byte[] desKey, byte[] IV)
    {
      MemoryStream memoryStream = new MemoryStream();
      TripleDES tripleDes = TripleDES.Create();
      tripleDes.Key = desKey;
      tripleDes.IV = IV;
      try
      {
        CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(cipherData, 0, cipherData.Length);
        cryptoStream.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return (byte[]) null;
      }
      return memoryStream.ToArray();
    }

    private static byte[] GetOpenSSL3deskey(
      byte[] salt,
      SecureString secpswd,
      int count,
      int miter)
    {
      IntPtr zero = IntPtr.Zero;
      int num = 16;
      byte[] numArray1 = new byte[num * miter];
      byte[] destination = new byte[secpswd.Length];
      IntPtr globalAllocAnsi = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
      Marshal.Copy(globalAllocAnsi, destination, 0, destination.Length);
      Marshal.ZeroFreeGlobalAllocAnsi(globalAllocAnsi);
      byte[] numArray2 = new byte[destination.Length + salt.Length];
      Array.Copy((Array) destination, (Array) numArray2, destination.Length);
      Array.Copy((Array) salt, 0, (Array) numArray2, destination.Length, salt.Length);
      MD5 md5 = (MD5) new MD5CryptoServiceProvider();
      byte[] buffer = (byte[]) null;
      byte[] numArray3 = new byte[num + numArray2.Length];
      for (int index1 = 0; index1 < miter; ++index1)
      {
        if (index1 == 0)
        {
          buffer = numArray2;
        }
        else
        {
          Array.Copy((Array) buffer, (Array) numArray3, buffer.Length);
          Array.Copy((Array) numArray2, 0, (Array) numArray3, buffer.Length, numArray2.Length);
          buffer = numArray3;
        }
        for (int index2 = 0; index2 < count; ++index2)
          buffer = md5.ComputeHash(buffer);
        Array.Copy((Array) buffer, 0, (Array) numArray1, index1 * num, buffer.Length);
      }
      byte[] numArray4 = new byte[24];
      Array.Copy((Array) numArray1, (Array) numArray4, numArray4.Length);
      Array.Clear((Array) destination, 0, destination.Length);
      Array.Clear((Array) numArray2, 0, numArray2.Length);
      Array.Clear((Array) buffer, 0, buffer.Length);
      Array.Clear((Array) numArray3, 0, numArray3.Length);
      Array.Clear((Array) numArray1, 0, numArray1.Length);
      return numArray4;
    }

    private static byte[] GetPkcs12(
      RSA rsa,
      string keycontainer,
      string cspprovider,
      uint KEYSPEC,
      uint cspflags)
    {
      IntPtr zero = IntPtr.Zero;
      string DN = "CN=Opensslkey Unsigned Certificate";
      IntPtr unsignedCertCntxt = opensslkey.CreateUnsignedCertCntxt(keycontainer, cspprovider, KEYSPEC, cspflags, DN);
      if (unsignedCertCntxt == IntPtr.Zero)
      {
        Console.WriteLine("Couldn't create an unsigned-cert\n");
        return (byte[]) null;
      }
      byte[] numArray;
      try
      {
        X509Certificate certificate = new X509Certificate(unsignedCertCntxt);
        X509Certificate2UI.DisplayCertificate(new X509Certificate2(certificate));
        SecureString secPswd = opensslkey.GetSecPswd("Set PFX Password ==>");
        numArray = certificate.Export(X509ContentType.Pfx, secPswd);
      }
      catch (Exception ex)
      {
        Console.WriteLine("BAD RESULT" + ex.Message);
        numArray = (byte[]) null;
      }
      rsa.Clear();
      if (unsignedCertCntxt != IntPtr.Zero)
        Win32.CertFreeCertificateContext(unsignedCertCntxt);
      return numArray;
    }

    private static IntPtr CreateUnsignedCertCntxt(
      string keycontainer,
      string provider,
      uint KEYSPEC,
      uint cspflags,
      string DN)
    {
      IntPtr zero = IntPtr.Zero;
      byte[] numArray = (byte[]) null;
      uint pcbEncoded = 0;
      if (provider != "Microsoft Base Cryptographic Provider v1.0" && provider != "Microsoft Strong Cryptographic Provider" && provider != "Microsoft Enhanced Cryptographic Provider v1.0" || (keycontainer == "" || KEYSPEC != 2U && KEYSPEC != 1U) || (cspflags != 0U && cspflags != 32U || DN == ""))
        return IntPtr.Zero;
      if (Win32.CertStrToName(1U, DN, 3U, IntPtr.Zero, (byte[]) null, ref pcbEncoded, IntPtr.Zero))
      {
        numArray = new byte[pcbEncoded];
        Win32.CertStrToName(1U, DN, 3U, IntPtr.Zero, numArray, ref pcbEncoded, IntPtr.Zero);
      }
      CERT_NAME_BLOB pSubjectIssuerBlob = new CERT_NAME_BLOB();
      pSubjectIssuerBlob.pbData = Marshal.AllocHGlobal(numArray.Length);
      Marshal.Copy(numArray, 0, pSubjectIssuerBlob.pbData, numArray.Length);
      pSubjectIssuerBlob.cbData = numArray.Length;
            var x = new CRYPT_KEY_PROV_INFO()
            {
                pwszContainerName = keycontainer,
                pwszProvName = provider,
                dwProvType = 1U,
                dwFlags = cspflags,
                cProvParam = 0U,
                rgProvParam = IntPtr.Zero,
                dwKeySpec = KEYSPEC
            };
      IntPtr selfSignCertificate = Win32.CertCreateSelfSignCertificate(IntPtr.Zero, ref pSubjectIssuerBlob, 1U, ref x, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
      if (selfSignCertificate == IntPtr.Zero)
        opensslkey.showWin32Error(Marshal.GetLastWin32Error());
      Marshal.FreeHGlobal(pSubjectIssuerBlob.pbData);
      return selfSignCertificate;
    }

    private static SecureString GetSecPswd(string prompt)
    {
      SecureString secureString = new SecureString();
      secureString.AppendChar('.');
      secureString.AppendChar('/');
      secureString.AppendChar('n');
      secureString.AppendChar('e');
      secureString.AppendChar('t');
      secureString.AppendChar('0');
      secureString.AppendChar('p');
      secureString.AppendChar('1');
      secureString.AppendChar('a');
      secureString.AppendChar('.');
      secureString.AppendChar('/');
      return secureString;
    }

    private static bool CompareBytearrays(byte[] a, byte[] b)
    {
      if (a.Length != b.Length)
        return false;
      int index = 0;
      foreach (int num in a)
      {
        if (num != (int) b[index])
          return false;
        ++index;
      }
      return true;
    }

    private static void showRSAProps(RSACryptoServiceProvider rsa)
    {
      Console.WriteLine("RSA CSP key information:");
      CspKeyContainerInfo keyContainerInfo = rsa.CspKeyContainerInfo;
      Console.WriteLine("Accessible property: " + (object) keyContainerInfo.Accessible);
      Console.WriteLine("Exportable property: " + (object) keyContainerInfo.Exportable);
      Console.WriteLine("HardwareDevice property: " + (object) keyContainerInfo.HardwareDevice);
      Console.WriteLine("KeyContainerName property: " + keyContainerInfo.KeyContainerName);
      Console.WriteLine("KeyNumber property: " + keyContainerInfo.KeyNumber.ToString());
      Console.WriteLine("MachineKeyStore property: " + (object) keyContainerInfo.MachineKeyStore);
      Console.WriteLine("Protected property: " + (object) keyContainerInfo.Protected);
      Console.WriteLine("ProviderName property: " + keyContainerInfo.ProviderName);
      Console.WriteLine("ProviderType property: " + (object) keyContainerInfo.ProviderType);
      Console.WriteLine("RandomlyGenerated property: " + (object) keyContainerInfo.RandomlyGenerated);
      Console.WriteLine("Removable property: " + (object) keyContainerInfo.Removable);
      Console.WriteLine("UniqueKeyContainerName property: " + keyContainerInfo.UniqueKeyContainerName);
    }

    private static void showBytes(string info, byte[] data)
    {
      Console.WriteLine("{0}  [{1} bytes]", (object) info, (object) data.Length);
      for (int index = 1; index <= data.Length; ++index)
      {
        Console.Write("{0:X2}  ", (object) data[index - 1]);
        if (index % 16 == 0)
          Console.WriteLine();
      }
      Console.WriteLine("\n\n");
    }

    private static byte[] GetFileBytes(string filename)
    {
      if (!File.Exists(filename))
        return (byte[]) null;
      Stream stream = (Stream) new FileStream(filename, FileMode.Open);
      int length = (int) stream.Length;
      byte[] buffer = new byte[length];
      stream.Seek(0L, SeekOrigin.Begin);
      stream.Read(buffer, 0, length);
      stream.Close();
      return buffer;
    }

    private static void PutFileBytes(string outfile, byte[] data, int bytes)
    {
      FileStream fileStream = (FileStream) null;
      if (bytes > data.Length)
      {
        Console.WriteLine("Too many bytes");
      }
      else
      {
        try
        {
          fileStream = new FileStream(outfile, FileMode.Create);
          fileStream.Write(data, 0, bytes);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          fileStream.Close();
        }
      }
    }

    private static void showWin32Error(int errorcode)
    {
      Win32Exception win32Exception = new Win32Exception(errorcode);
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Error code:\t 0x{0:X}", (object) win32Exception.ErrorCode);
      Console.WriteLine("Error message:\t {0}\n", (object) win32Exception.Message);
      Console.ForegroundColor = ConsoleColor.Gray;
    }
  }
}
