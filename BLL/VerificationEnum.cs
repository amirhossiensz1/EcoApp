using System;

namespace BLL
{
    [Flags]
    public enum VerificationEnum 
    { 
        PasswordOrFingerPrintOrCardOrface = 0 ,
        FingerPrint =1,
        Pin = 2 ,
        Password  = 3,
        Card = 4,
        FingerPrintOrPassword = 5 ,
        FingerPrintOrCard = 6,
        PasswordOrCard = 7,
        PinAndFingerPrint =8,
        FingerPrintAndPassword = 9,
        FingerPrintAndCard = 10 ,
        PasswordAndCard = 11 ,
        FingerPrintAndPasswordAndCard = 12,
        PinAndFingerPrintAndPassword = 13,
        FingerPrintAndCardOrPin = 14,
        Face = 15,
        FaceAndFingerPrint = 16,
        FaceAndPassword = 17,
        FaceAndCard = 18,
        FaceAndFingerPrintAndCard = 19,
        FaceAndFingerPrintAndPassword = 20
    }
}