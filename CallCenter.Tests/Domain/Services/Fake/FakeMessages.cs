namespace CallCenter.Tests.Domain.Services.Fake
{
    using System.Collections.Generic;
    
    public class FakeMessages
    {
        public static List<string> Messages()
        {

            return new List<string>
            {
                "11:51:00 CLIENTE1: Hola",
                "11:51:05 ASESOR1: Hola CLIENTE1, bienvenido al centro de servicio.",
                "",
                "11:55:00 CLIENTE2: Hola",
                "11:55:05 ASESOR2: Hola CLIENTE2, bienvenido al centro de servicio."
            };
        }
    }
}
