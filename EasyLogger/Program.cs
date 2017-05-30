using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLogger {
    class Program {
        static void Main(string[] args) {
            EzLogMsg msg = new EzLogMsg(@"
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus vel sodales augue. Phasellus suscipit, ante sed lobortis commodo, magna ipsum scelerisque tellus, volutpat posuere quam est eget ex. Phasellus eget nulla felis. Aliquam at velit augue. Quisque ut elit fermentum, scelerisque risus sit amet, interdum nulla. Morbi hendrerit suscipit ex eget porta. Etiam feugiat elit urna, eget lobortis dolor fermentum vitae. Nam tempus finibus ligula in semper. Donec porttitor sed justo ut ornare. Donec gravida turpis vitae enim efficitur pulvinar. Etiam tristique leo ac sagittis consectetur. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
{2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222}
Proin tempor eu neque nec accumsan. Pellentesque vel condimentum elit, sed posuere turpis. Quisque pharetra finibus viverra. Integer quam erat, consectetur feugiat orci eu, semper tempor urna. Curabitur mattis tortor eget diam egestas tincidunt. In quis sem ac nibh vulputate vulputate. Ut at lorem at metus cursus posuere dictum placerat magna. Sed ultricies imperdiet cursus. Maecenas vitae ante at urna aliquet porta. Sed justo lorem, porttitor vel condimentum quis, lacinia nec ipsum. Cras porttitor leo sapien, nec viverra quam porta nec. In lacinia, lectus quis pretium pharetra, elit tortor accumsan metus, et viverra elit arcu et elit.
");
            msg.Header = "lol i do this tooooo";
            msg.Footer = "Oh noo    i dont want that";

            List<string> linedmsg = msg.GetFormattedMessage(60);
            foreach(string line in linedmsg) {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
