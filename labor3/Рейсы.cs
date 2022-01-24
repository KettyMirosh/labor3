using System;
using System.Collections.Generic;

namespace labor3
{
    public partial class Рейсы
    {
        public long НомерРейса { get; set; }
        public string? Самолет { get; set; }
        public byte[]? ДатаРейса { get; set; }
        public byte[]? Время { get; set; }
        public string? ГородПрибытия { get; set; }
    }
}
