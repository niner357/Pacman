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
            for(int y = 0; y < 32; y++)
            {
                for(int x = 0; x < 32; x++)
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
