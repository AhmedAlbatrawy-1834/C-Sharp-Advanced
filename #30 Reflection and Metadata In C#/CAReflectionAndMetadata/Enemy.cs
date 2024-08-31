namespace CAReflectionAndMetadata
{
    /*#################### Instantiating Types Class ####################*/

    abstract class Enemy
    {
        public string Name { get; protected set; }
        public int Speed { get; protected set; }
        public int HitPowers { get; protected set; }
        public int Strength { get; protected set; }

        public override string ToString()
        {
            return $"{{Name:{Name}, Speed:{Speed},  Hit Power:{HitPowers},   Strength:{Strength}}}";
        }
    }




}
