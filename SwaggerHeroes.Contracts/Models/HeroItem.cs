using SwaggerHeroes.Core.Enums;

namespace SwaggerHeroes.Core.Models
{
    public class HeroItem
    {
        public string Name { get; set; }
        public string Powers { get; set; }
        public bool HasCape { get; set; }
        public DateTime Created { get; set; }
        public bool IsAlive { get; set; }
        public Category Category { get; set; }
    }
}