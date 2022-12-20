using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
/*
namespace encrypt_decrypt_string
{
    class Program
    {
        static string Encrypt()
        {
            try
            {
                string textToEncrypt = "Su5TUzIxAAADra4ECAUHCc7QAAAfrGwBAAAAg1Afuq3FAO0M0AAUAAChxwD1AAgNFwCirfkO5QDvAOIObq3jANUPZwB4ANSiigCHAOMPEgCDrWoOCQEhAYYNOq0SAdEOvAAAAO+huQDxAOoNXwD5rdgPzAAAAYsN8a26AA0PxQBJAOijfAAGAc4PpQCqrdoKowA1AQsN/K1uAAEIlAAOANyi0gDEAAIMRADlrU4PsQAQAYkP1K0IAUMNswBDAOmicwCdAFkPJwCGrfoOqQBgACwIk61RAdcNoAFQ76pCSQMVGhUbYb8GjZzHMQ5e/JeMrUnD2NIgtYmjAd2nXP16geYFx4ydV3r8KHN9gpt00K/mH9P3qwdW/5gqIQGV7q3qZOSyMw8QnvAaDA+M3+ZQDM1m6gwbDhG7JAF9gsH2Y/R5LWP62QWNhk76DVWDhm/35gk3m+y2/5Ca9p72DQP+twAXuX1OeL+AIa3/ZNZ02fQkPxGxpAGSgU4CVIIJ1XeFGJP+EBsEza/yCMMBhgi6j2CmuIv2fiA2xAIUsXwXAPEtegb+g8RTZcJbexPFwDfGwGz/WsH/BGRpqwAENICLwc4AvOtowMJka8HMAQuWfHh4wQkBzkJ+1WvBDgCbRKXBRm3Awf/BwUPJAQ/mgYV/wcF71QEO/4GFg8DBwAWA/LcAD1mAeMKZdMFSwEl0/2XCwAB68F/AZBoBC6V9w9rAeMB7wcCxwfzPWgYAo2ZktcELrA1nfcCEe8MA+t18gMIEARC8g3ahAdd+cMP+u3ZzqQAOgIOEFcXdhMBmwMHBwcAFwH1tWT4EAOWHPywKra+MZG9awc4BCSKHwnlnewvEC5srjcP+g8EFxAqjK4ELAG2hYAfAc23+jwoAcqGSwF5u/1kPAQupTIuQ1sPCZAcBDnSJejwCAPO7A/3NARIWkZbCw/0GxdbFVyL/DgC0yKfCacZaMwwBE89SwcFvwsLBwsHBBAkDftMA/v3/KjoLA9LmVsJbwME4PQqta+pTXW3+zgDiQIfFksLBwPgKA0TvHP39MT3PALhC5/77/v39OP78pAHn8yYjODoKA2T3+voYwP/uDQK2+Kv/xcGRAIbDpQHS/j3+TIkIEzQBU8L+aMDCENunO/3/RAcQuQxTbcHANAQQsNRMV6gQByVG/0/AEQ6IQf87BBAJizSkthAIYdbCgwb+jmzCwcTEw3CzwESqEaVY1m9MwhDIvEhLVxEQ0ZLQcmzDw8fJxcMFwTw=";
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        static void Main(string[] args)
        {
            string encrypted = Encrypt();
            Console.WriteLine(encrypted);
        }
    }
}*/

namespace encrypt_decrypt_string
{
    class Program
    {
        static string Decrypt()
        {
            try
            {
                string textToDecrypt = "ZFnstpXj4bOqEIZAoDJQHwG/36iT0oLBFrVPpwEc4hykijO41L880LXp1DRjEB+gSS2TJ6EtES6+3aBH1uyqai9BK2W56XpoquEVFhsPZDCDUPx3q0g5sziuqoDx0C4nsBQs3dmk7IMeBS+K/eI02td1dFklKvK2wNRP0C4dJqYCLkGGl0+r6do+R+DHRIKy0yPlQpT4C8QNCdTK6Y3ivdfWS7TMo2bgVHHWWdx+X/v4rKcvFhNNlmqw91fBS6LKhuFl7lDoZgkte/tOe+xAcEuljMixhcBeOADCjcDWEXj/mmvYApgxhSSWvk0KZTO1qaHXfdvZe8SdoIkbDc6BWnDrT7/OCsXcPiBZbnHyAv6ZwoI1elgAYufsmR69fk0LtUWd+FgH+IMDKZYpfpufl91MXtvbWY7iSbBUHCBFSJ8sGckkHW0XlK8Ak4NSTmrF1rI3X0CCc42tc66lrxZfH4wVw1VLKRyxAYR7pdvndlNXM9u/Wflr6Uhx9OvaxYd/7VZMfnG/Wc8jBDANqh2WEGUcqmsqFSwjBoWhqwC3kyGxo9Z7E4BC0Otpv6AXsIO0Lpu6Plkbg79W2rN0TcVBmmSZoq+zXXhLCwXx5SDba/6AoA2NnvbGiXh8aCJcG7cpbsHp2Xh3KdlWEKqdfNI4IR+Vmh7xZMp1y5FOZFcB8gVuUOYk/Qz+NMcWeIOlWCe+GtuUVvv6WeKoJa9Mf0O7LzNrGZzo6+2WhfkqYyZe0oqpAET/jrhyng6fc+uDTeUk3mf7Kw9fPeOS2R8mq3IpbBYGHar0/2eF3XLaYPr16fJ9X09C1Lhw6rgGcmoJ06r61x28u+UHSRdRGK+/boQEVuRyAYMqdpNlYzKK7+vc/aUFJvfND7+yAXeYEpHn02/dCE46FXdJzgO1xrC2m4DPLfs+M/hsrw77eInPaYK1g+aToJn51cQHkwszhrjMrkcwXtqAI8i/WlJ3oQp8pSn2ljcZrbXjwd3nYaJkVFCgFg/pRIZU2AySt1uLrIyVUEEIM13KntCDyRQaoj4sClFWQSFvAkwyRUxvIj87uau4+5c2B0ghKgEso2phxOXSMLytrCWyKbhMQLqHm99XAKNjpphCFKNfwK8Ja6DMBylCcl9nAUuPNkdqbOao66i9n3UjHBaVqKGA26/eJPpinUbpz/oluxCOkxLqyu9EPc23cpWNbjmRt4I4Nu+BAFYnAnRpqrJEY8N1l8CdHrqg3EDUjMyH4X7atugMcYY3PKA6TFMrQzFPkl1RR6QpdzbPpaR9nGsjlhYHbxNpMwcDeOno/Jj6m1gyFH8imWUplMt+muv9RyIyp/Ej28rdPNBoseNm/gH6Eu2vVMKv+2dMgi1bJtQbFp3S3UBzJy6ealVvXY7yWjAFkiuuCHG+xurdOZlYomfh2tAr9oU+YzHpb2mTC/EbiB4aZmlKFPRU21TLeiKY3cv1p6yfjEE5XRWhM9xxc3Wot4gyROdL/Ps0ik/JL1JXUhOkCQao+Fln/EIgzKG1fkf8mCDXn+skI0frqm/RJwEB2nxNYLREjvu4XZHiZPMAbRD5uXSRxfAOL0bE7kUXBgw4fxFakBEcFbGAo9ir/lOPIHKr3lya+skIK4DKAmNd3D9OhAnRk1RmOVJuEXGQcqUGlccKJ4z/4dI3d90RlsRk0XS1KV/0O6XKjt3mVg==";
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
        static void Main(string[] args)
        {
            string decrypted = Decrypt();
            Console.WriteLine(decrypted);
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            Console.WriteLine($"\n{str}");
        }
    }
}