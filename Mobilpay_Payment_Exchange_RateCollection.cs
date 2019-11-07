// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Exchange_RateCollection
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System.Collections;

namespace MobilpayEncryptDecrypt
{
  public class Mobilpay_Payment_Exchange_RateCollection : CollectionBase
  {
    public Mobilpay_Payment_Exchange_Rate this[int index]
    {
      get
      {
        return this.List[index] as Mobilpay_Payment_Exchange_Rate;
      }
    }

    public int Add(Mobilpay_Payment_Exchange_Rate exchange_rate)
    {
      return this.List.Add((object) exchange_rate);
    }
  }
}
