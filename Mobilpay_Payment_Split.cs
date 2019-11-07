// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Split
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Collections;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Split : CollectionBase
  {
    public Mobilpay_Payment_Split_Destination this[int index]
    {
      get
      {
        return this.List[index] as Mobilpay_Payment_Split_Destination;
      }
    }

    public int Add(Mobilpay_Payment_Split_Destination item)
    {
      return this.List.Add((object) item);
    }
  }
}
