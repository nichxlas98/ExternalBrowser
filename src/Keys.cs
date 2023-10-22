using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExternalBrowser
{
    public class Key
    {
        public static int FromString(string key)
        {
            switch (key)
            {
                case "VK_BACK":
                    return 0x08;  // Backspace

                case "VK_TAB":
                    return 0x09;  // Tab

                case "VK_ENTER":
                    return 0x0D;  // Enter

                case "VK_SHIFT":
                    return 0x10;  // Shift

                case "VK_CTRL":
                    return 0x11;  // Ctrl

                case "VK_ALT":
                    return 0x12;  // Alt

                case "VK_PAUSE":
                    return 0x13;  // Pause/Break

                case "VK_CAPS_LOCK":
                    return 0x14;  // Caps Lock

                case "VK_ESCAPE":
                    return 0x1B;  // Esc

                case "VK_SPACE":
                    return 0x20;  // Space

                case "VK_PAGE_UP":
                    return 0x21;

                case "VK_PAGE_DOWN":
                    return 0x22;

                case "VK_END":
                    return 0x23;

                case "VK_HOME":
                    return 0x24;

                case "VK_LEFT":
                    return 0x25;

                case "VK_UP":
                    return 0x26;

                case "VK_RIGHT":
                    return 0x27;

                case "VK_DOWN":
                    return 0x28;

                case "VK_PRINT_SCREEN":
                    return 0x2C;  // Print Screen

                case "VK_INSERT":
                    return 0x2D;

                case "VK_DELETE":
                    return 0x2E;

                case "VK_0":
                    return 0x30;  // 0

                case "VK_1":
                    return 0x31;  // 1

                case "VK_2":
                    return 0x32;  // 2

                case "VK_3":
                    return 0x33;  // 3

                case "VK_4":
                    return 0x34;  // 4

                case "VK_5":
                    return 0x35;  // 5

                case "VK_6":
                    return 0x36;  // 6

                case "VK_7":
                    return 0x37;  // 7

                case "VK_8":
                    return 0x38;  // 8

                case "VK_9":
                    return 0x39;  // 9

                case "VK_A":
                    return 0x41;  // A

                case "VK_B":
                    return 0x42;  // B

                case "VK_C":
                    return 0x43;  // C

                case "VK_D":
                    return 0x44;  // D

                case "VK_E":
                    return 0x45;  // E

                case "VK_F":
                    return 0x46;  // F

                case "VK_G":
                    return 0x47;  // G

                case "VK_H":
                    return 0x48;  // H

                case "VK_I":
                    return 0x49;  // I

                case "VK_J":
                    return 0x4A;  // J

                case "VK_K":
                    return 0x4B;  // K

                case "VK_L":
                    return 0x4C;  // L

                case "VK_M":
                    return 0x4D;  // M

                case "VK_N":
                    return 0x4E;  // N

                case "VK_O":
                    return 0x4F;  // O

                case "VK_P":
                    return 0x50;  // P

                case "VK_Q":
                    return 0x51;  // Q

                case "VK_R":
                    return 0x52;  // R

                case "VK_S":
                    return 0x53;  // S

                case "VK_T":
                    return 0x54;  // T

                case "VK_U":
                    return 0x55;  // U

                case "VK_V":
                    return 0x56;  // V

                case "VK_W":
                    return 0x57;  // W

                case "VK_X":
                    return 0x58;  // X

                case "VK_Y":
                    return 0x59;  // Y

                case "VK_Z":
                    return 0x5A;  // Z

                default:
                    throw new ArgumentException("Invalid key string", nameof(key));
            }
        }
    }
}
