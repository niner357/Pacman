using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelCreator
{
    public class Map
    {
        public Field[] Fields { get; private set; }

        public Map()
        {
            Fields = new Field[1024];
            int i = 0;
            for(int y = 0; y < 512; y+=16)
            {
                for(int x = 0; x < 512; x += 16)
                {
                    Field field = new Field(x, y);
                    field.Type = FieldType.WAY;
                    Fields[i] = field;
                    i++;
                }
            }
        }
    }
}
