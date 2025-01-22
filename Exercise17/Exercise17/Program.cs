/*
 * Dog class

Define a Dog class. Each Dog will have a name(string), breed (string), and weight (int) fields.

This class will have two constructors:

    The first takes name, breed, and weight parameters (in this order).

    The second takes only the name and weight parameters (in this order). In this case, the breed should be assigned the "mixed-breed" value.

This class will expose a single public method called Describe, returning a string describing the dog.

    For a dog named Lucky, with the breed "german shepherd" and weight of 40, this method should return "This dog is named Lucky, it's a german shepherd, and it weighs 40 kilograms, so it's a large dog."

    For a dog named Tina, with the breed "shar pei" and weight of 25, this method should return "This dog is named Tina, it's a shar pei, and it weighs 25 kilograms, so it's a medium dog."

The rule for translating the dog's weight to the weight description is as follows:

    For dogs lighter than 5 kilos, it is "tiny".

    For dogs weighing 5 kilos or more but less than 30 kilos, it is "medium".

    For other dogs, it is "large".
 */

using System;

namespace Coding.Exercise
{
    public class Dog
    {
        private string _name;
        private string _breed;
        private string _size;
        private int _weight;

        public Dog(string name, string breed, int weight)
        {
            _name = name;
            _breed = breed;
            _weight = weight;
            _size = DefineSize(weight);
        }

        public Dog(string name, int weight) : this(name, "mixed-breed", weight)
        {

        }

        public string Describe()
        {
            return ($"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a {_size} dog.");
        }

        private string DefineSize(int weight)
        {
            if (weight > 30)
            {
                return "large";
            }
            else if (weight > 5)
            {
                return "medium";
            }
            else
            {
                return "tiny";
            }
        }
    }
}
