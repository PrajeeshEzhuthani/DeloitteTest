using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class MarsRoverInputModel
    {
        public MarsRoverInputModel()
        {
            Position = new MarsRoverOutputModel();
        }

        public MarsRoverOutputModel Position { get; set; }
        public string Instructions { get; set; }

    }
}
