﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp45
{
    public class MyCanvas
    {
        public const int MaxWidth = 800;
        public const int MaxHeight = 600;
        private static int MaxButtons = 3;
        private static MyButton[] buttons = new MyButton[MaxButtons];
        private static int buttonIndex = 0;

        public static bool CreateNewButton(int x1, int y1, int x2, int y2)
        {
            bool forContinuing = true;
            buttonIndex = 0;

            if (buttonIndex < MaxButtons)
            {
                Point New_TopLeftBotton = new Point(x1, y1);
                Point New_TopRigthBotton = new Point(x2, y2);
                buttons[buttonIndex] = new MyButton(New_TopLeftBotton, New_TopRigthBotton);
                buttons[buttonIndex].SetTopLeft(New_TopLeftBotton);
                buttons[buttonIndex].SetBotomRight(New_TopRigthBotton);
                buttonIndex++;
                forContinuing = true;
            }
            else
                forContinuing = false;
            return forContinuing;
        }
        public static bool MoveButton(int buttonNumber, int x, int y)
        {
            int oldX, oldY;
            oldX = buttons[buttonNumber].GetBottomRigth().GetX();
            oldY = buttons[buttonNumber].GetBottomRigth().GetY();
            buttons[buttonNumber].SetBotomRight(new Point(oldX + x, oldY + y));
            oldX = buttons[buttonNumber].GetTopLeft().GetX();
            oldY = buttons[buttonNumber].GetTopLeft().GetY();
            buttons[buttonNumber].SetTopLeft(new Point(oldX + x, oldY + y));

            return true;
        }
        public static bool DeleteLastButton()
        {
            if (buttonIndex > 0)
            {
                buttons[buttonIndex].SetTopLeft(new Point(0, 0));
                buttons[buttonIndex].SetBotomRight(new Point(0, 0));
                buttonIndex--;
                return true;

            }
            else
                return false;
        }
        public static void ClearAllButtons()
        {
            if (buttonIndex > 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetTopLeft(new Point(0, 0));
                    buttons[i].SetBotomRight(new Point(0, 0));
                }
                buttonIndex = 0;
            }
        }
        public static int GetCurrentNumberOfButtons()
        {
            return (buttonIndex + 1);
        }
        public static int GetMaxNumberOfNumberOfButtons()
        {
            return MaxButtons;
        }
        public static int GetTheMaxWidthOfButton()
        {
            int MaxWidthOfAButton = 0;

            if (buttonIndex > 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if ((buttons[i].GetBottomRigth().GetX() - buttons[i].GetTopLeft().GetX()) > MaxWidthOfAButton)
                        MaxWidthOfAButton = buttons[i].GetBottomRigth().GetX() - buttons[i].GetTopLeft().GetX();

                }
                return MaxWidthOfAButton;
            }
            else
            {
                return 0;
            }
        }
        public static void Print()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                Console.WriteLine(buttons[i]);

            }
        }
        public static bool IsPointInsideButton(int x, int y)
        {
            return true;
        }
        public static bool CheckIfAnyButtonIsOverLapping()
        {
            return true;
        }

        public override string ToString()
        {
            return $"It was hard...";
        }
    }
}
