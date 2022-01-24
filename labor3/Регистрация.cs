using System;
using System.Collections.Generic;

namespace labor3
{
    public partial class Регистрация
    {
        public long Код { get; set; }
        public long? НомерйРейса { get; set; }
        public long? Пассажир { get; set; }
        public string? ВыборМеста { get; set; }
        public string? РегистрацияПройдена { get; set; }
        public long? Багаж { get; set; }
    }
}
