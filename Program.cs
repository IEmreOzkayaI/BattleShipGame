using System;

namespace BattleShipGame
{
    class Program
    {

        static void Main(string[] args)
        {
            int origRow;
            int origCol;
            int key, pX, pY;
            double pArea1, pArea2, pArea3, pAreaTotal;
            int aX = 0, aY = 0, bX = 0, bY = 0, cX = 0, cY = 0;

            double aLen = 0, bLen = 0, cLen = 0;
            double aDeg = 0, bDeg = 0, cDeg = 0;
            double aRad = 0, bRad = 0, cRad = 0;
            double area = 0, perimeter = 0, semiperimeter = 0;
            double aMedX = 0, aMedY = 0, bMedX = 0, bMedY = 0, cMedX = 0, cMedY = 0;
            double centroidX = 0, centroidY = 0;
            double aBisector = 0;
            double inscribedR, circumscribedR;
            double inscribedArea = 0, circumscribedArea = 0;
            string triangleType1 = "", triangleType2 = "";

            bool shipExists = false;

            double player1Score = 60;
            double player2Score = 30;
            double player3Score = 10;

            string player1Name = "Nazan Kaya";
            string player2Name = "Ali Kurt";
            string player3Name = "Sibel Arslan";

            String userName;

            Console.WriteLine("- MENU -");
            Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW : ");
            Console.WriteLine("1 - Enter ship location");
            Console.WriteLine("2 - Ship info");
            Console.WriteLine("3 - Shoot at the ship ");
            Console.WriteLine("4 - Show high score table");
            Console.WriteLine("5 - Exit ");
            while (true)
            {
                Console.Write("SELECTION : ");
                key = Convert.ToInt32(Console.ReadLine());

                if (key == 1)
                {

                    Console.WriteLine("\nPlease enter the location of the ship");
                    Console.Write("Ax : ");
                    aX = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Ay : ");
                    aY = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Bx : ");
                    bX = Convert.ToInt16(Console.ReadLine());
                    Console.Write("By : ");
                    bY = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Cx : ");
                    cX = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Cy : ");
                    cY = Convert.ToInt16(Console.ReadLine());

                    if ((aX <= 30 && aX > 0) && (aY <= 12 && aY > 0) && (bX <= 30 && bX > 0) && (bY <= 12 && bY > 0) && (cX <= 30 && cX > 0) && (cY <= 12 && cY > 0))
                    {
                        //length of the edges
                        aLen = Math.Sqrt(((bX - cX) * (bX - cX)) + ((bY - cY) * (bY - cY)));
                        bLen = Math.Sqrt(((aX - cX) * (aX - cX)) + ((aY - cY) * (aY - cY)));
                        cLen = Math.Sqrt(((bX - aX) * (bX - aX)) + ((bY - aY) * (bY - aY)));

                        if ((bLen + cLen > aLen && aLen > Math.Abs(bLen - cLen)) && (aLen + cLen > bLen && bLen > Math.Abs(aLen - cLen)) && (aLen + bLen > cLen && cLen > Math.Abs(aLen - bLen)))
                        {
                            Console.Clear();
                            Console.WriteLine("- MENU -");
                            Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW : ");
                            Console.WriteLine("1 - Enter ship location");
                            Console.WriteLine("2 - Ship info");
                            Console.WriteLine("3 - Shoot at the ship ");
                            Console.WriteLine("4 - Show high score table");
                            Console.WriteLine("5 - Exit ");
                            Console.WriteLine("\nPlease enter the location of the ship");

                            Console.WriteLine("\nA : ({0},{1})", aX, aY);
                            Console.WriteLine("B : ({0},{1})", bX, bY);
                            Console.WriteLine("C : ({0},{1})", cX, cY);

                            origRow = Console.CursorTop;
                            origCol = Console.CursorLeft;

                            // HORIZONTAL
                            Console.Write("\n\n12|\n11|\n10|\n 9|\n 8|\n 7|\n 6|\n 5|\n 4|\n 3|\n 2|\n 1|\n +");
                            Console.WriteLine(" ------------------------------");
                            Console.Write("   12345678901234567890123456789");

                            // Points
                            Console.SetCursorPosition(origCol + aX + 2, origRow + 14 - aY);
                            Console.Write("A");

                            Console.SetCursorPosition(origCol + bX + 2, origRow + 14 - bY);
                            Console.Write("B");

                            Console.SetCursorPosition(origCol + cX + 2, origRow + 14 - cY);
                            Console.Write("C");

                            Console.SetCursorPosition(origCol + 32, origRow + 15);
                            Console.Write("0\n");

                            //Area and Perimeter
                            area = Math.Abs((double)(aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2);
                            perimeter = aLen + bLen + cLen;
                            semiperimeter = perimeter / 2;

                            //Angles(Radian)
                            aRad = Math.Acos(((bLen * bLen) + (cLen * cLen) - (aLen * aLen)) / (2 * bLen * cLen));
                            bRad = Math.Acos(((aLen * aLen) + (cLen * cLen) - (bLen * bLen)) / (2 * aLen * cLen));
                            cRad = Math.Acos(((bLen * bLen) + (aLen * aLen) - (cLen * cLen)) / (2 * bLen * aLen));

                            //Angles(Degrees)
                            aDeg = aRad * 180 / Math.PI;
                            bDeg = bRad * 180 / Math.PI;
                            cDeg = cRad * 180 / Math.PI;

                            //Median Points
                            aMedX = ((double)(bX + cX)) / 2;
                            aMedY = ((double)(bY + cY)) / 2;
                            bMedX = ((double)(aX + cX)) / 2;
                            bMedY = ((double)(aY + cY)) / 2;
                            cMedX = ((double)(aX + bX)) / 2;
                            cMedY = ((double)(aY + bY)) / 2;

                            //Centroid
                            centroidX = (double)(aX + ((double)(aMedX - aX) * 2 / 3));
                            centroidY = (double)(aY + ((double)(aMedY - aY) * 2 / 3));

                            //bisector of the point A
                            aBisector = 2 * Math.Sqrt(bLen * cLen * semiperimeter * (semiperimeter - aLen)) / (bLen + cLen);

                            //area of the inscribed circle
                            inscribedR = Math.Sqrt((semiperimeter - aLen) * (semiperimeter - bLen) * (semiperimeter - cLen) / semiperimeter);
                            inscribedArea = inscribedR * inscribedR * Math.PI;

                            //area of the circumscribed circle
                            circumscribedR = (aLen * bLen * cLen) / (4 * area);
                            circumscribedArea = circumscribedR * circumscribedR * Math.PI;

                            //type of the ship
                            if ((aDeg == bDeg) && (aDeg == cDeg) && (bDeg == cDeg))
                            {
                                triangleType1 = "Equilatera";
                                triangleType2 = "Acute-angled";
                            }
                            else
                            {
                                if ((aRad == bDeg) || (aDeg == cDeg) || (bDeg == cDeg))
                                    triangleType1 = "Isosceles";
                                else
                                    triangleType1 = "Scalene";

                                //Round function was required because of how floating point number work. Unless I did it the comparisons wouldn't work properly.
                                if ((Math.Round(aDeg, 5) > 90.0) || (Math.Round(bDeg, 5) > 90.0) || (Math.Round(cDeg, 5) > 90.0))
                                {
                                    triangleType2 = "Obtuse-angled";
                                }
                                else if ((Math.Round(aDeg, 5) == 90.0) || (Math.Round(bDeg, 5) == 90.0) || (Math.Round(cDeg, 5) == 90.0))
                                {
                                    triangleType2 = "Right-angled";
                                }
                                else
                                {
                                    triangleType2 = "Acute-angled";
                                }
                            }

                            shipExists = true;

                        }
                        else
                        {
                            String triangleError = "\nYou entered false value , because your ship is not a triangle ! Please enter right values ...";
                            Console.WriteLine(triangleError);
                            shipExists = false;
                        }

                    }
                    else
                    {
                        String coordinateError = "You entered false value , because your coordinates are not in coordinate plane.X axis 0 < x <= 30 ,  Y axis 0 < y <= 12 ";
                        Console.WriteLine(coordinateError);
                        shipExists = false;
                    }

                }
                else if (key == 2)
                {
                    if (shipExists == true)
                    {

                        Console.WriteLine("\nSHIP INFO");
                        Console.WriteLine("The size of the ship: a={0}  b={1}  c={2}", Math.Round(aLen, 2), Math.Round(bLen, 2), Math.Round(cLen, 2));
                        Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                        Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                        Console.WriteLine("The angles of the ship: A={0} B={1} C={2}", Math.Round(aDeg, 2), Math.Round(bDeg, 2), Math.Round(cDeg, 2));
                        Console.WriteLine("The median points:  ({0} , {1}) ({2} , {3}) ({4} , {5})", aMedX, aMedY, bMedX, bMedY, cMedX, cMedY);
                        Console.WriteLine("The centroid of the ship:  ({0} , {1})", Math.Round(centroidX, 2), Math.Round(centroidY, 2));
                        Console.WriteLine("The length of the bisector: " + Math.Round(aBisector, 2));
                        Console.WriteLine("The area of the inscribed circle: " + Math.Round(inscribedArea, 2));
                        Console.WriteLine("The area of circumscribed circle: " + Math.Round(circumscribedArea, 2));
                        Console.WriteLine("The type of the ship: {0} ({1})", triangleType1, triangleType2);
                    }
                    else
                    {
                        String noShipError = "There is no ship in the game";
                        Console.WriteLine(noShipError);

                    }

                }
                else if (key == 3)
                {
                    if (shipExists == true)
                    {
                        Random random = new Random();
                        pX = random.Next(1, 31);
                        pY = random.Next(1, 13);
                        Console.WriteLine("\nShoot : (" + pX + "," + pY + ")");
                        pArea1 = Math.Abs((double)(pX * (bY - cY) + bX * (cY - pY) + cX * (pY - bY)) / 2);
                        pArea2 = Math.Abs((double)(pX * (aY - cY) + aX * (cY - pY) + cX * (pY - aY)) / 2);
                        pArea3 = Math.Abs((double)(pX * (bY - aY) + bX * (aY - pY) + aX * (pY - bY)) / 2);
                        pAreaTotal = pArea1 + pArea2 + pArea3;
                        origRow = Console.CursorTop;
                        origCol = Console.CursorLeft;

                        // HORIZONTAL
                        Console.Write("\n\n12|\n11|\n10|\n 9|\n 8|\n 7|\n 6|\n 5|\n 4|\n 3|\n 2|\n 1|\n +");
                        Console.WriteLine(" ------------------------------");
                        Console.Write("   12345678901234567890123456789");

                        // Points
                        Console.SetCursorPosition(origCol + pX + 2, origRow + 14 - pY);
                        Console.Write("X");

                        Console.SetCursorPosition(origCol + aX + 2, origRow + 14 - aY);
                        Console.Write("A");

                        Console.SetCursorPosition(origCol + bX + 2, origRow + 14 - bY);
                        Console.Write("B");

                        Console.SetCursorPosition(origCol + cX + 2, origRow + 14 - cY);
                        Console.Write("C");

                        Console.SetCursorPosition(origCol + 32, origRow + 15);
                        Console.Write("0");



                        if (pAreaTotal != area)
                        {
                            string winScreen = "\n\nYour ship survived! Total score is : ";
                            Console.WriteLine(winScreen + Math.Round(area, 2));
                            Console.Write("Please Enter User Name : ");
                            userName = Console.ReadLine();

                            if (area > player1Score)
                            {
                                player3Name = player2Name;
                                player3Score = player2Score;

                                player2Score = player1Score;
                                player2Name = player1Name;

                                player1Name = userName;
                                player1Score = area;
                            }

                            else if (area > player2Score)
                            {
                                player3Name = player2Name;
                                player3Score = player2Score;

                                player2Name = userName;
                                player2Score = area;
                            }

                            else if (area > player3Score)
                            {
                                player3Name = userName;
                                player3Score = area;
                            }
                        }
                        else
                        {
                            string losingScreen = "\n\nYour ship sank! Total score is 0  ";
                            Console.WriteLine(losingScreen);
                        }
                    }
                    else
                    {
                        String noShipError = "There is no ship in the game";
                        Console.WriteLine(noShipError);

                    }
                }
                else if (key == 4)
                {
                    Console.WriteLine("\nHIGH SCORE TABLE\n");
                    Console.WriteLine("Name           Score");
                    Console.WriteLine("----           -----");
                    Console.Write(player1Name);
                    Console.SetCursorPosition(15, Console.CursorTop);
                    Console.WriteLine(player1Score);
                    Console.Write(player2Name);
                    Console.SetCursorPosition(15, Console.CursorTop);
                    Console.WriteLine(player2Score);
                    Console.Write(player3Name);
                    Console.SetCursorPosition(15, Console.CursorTop);
                    Console.WriteLine(player3Score);
                }
                else if (key == 5)
                {
                    shipExists = false;
                    String exitKeyValue = "You entered exit value !! Program will close!";
                    Console.WriteLine(exitKeyValue);
                    return;
                }
                else
                {
                    String keyValueError = "You entered invalid value !! Try again!";
                    Console.WriteLine(keyValueError);
                }
            }

        }

    }

}



