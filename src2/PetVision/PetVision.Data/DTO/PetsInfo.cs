using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVision.Data.DTO
{
    public class PetsInfo
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string Traits { get; set; }
        public string Issues { get; set; }
        public string AccordingTo { get; set; }
        public string Link { get; set; }
        public string Originated { get; set; }

        public int BreedCode { get; set; }
        public string SpecieCode { get; set; }
    }
}
