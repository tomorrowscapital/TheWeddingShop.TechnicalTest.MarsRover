using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;
using TheWeddingShop.TechnicalTest.MarsRover.Rovers;

namespace TheWeddingShop.TechnicalTest.MarsRover.Rovers
{
    /// <summary>
    /// Implement all movement logics of a Rover
    /// </summary>
    public class Rover : IVehicle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }
        private IArea _area { get; }

        public Rover(int x, int y, Direction direction, IArea area)
        {
            X = x;
            Y = y;
            Direction = direction;
            _area = area;
        }

        public void Move(IEnumerable<Movement> movements)
        {
            foreach (var movement in movements)
            {
                Move(movement);
            }
        }
        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.L:
                    TurnLeft();
                    break;
                case Movement.R:
                    TurnRight();
                    break;
                case Movement.M:
                    MoveForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.N:
                    if (Y + 1 <= _area.GetSize().Height)
                        Y += 1;
                    break;

                case Direction.E:
                    if (X + 1 <= _area.GetSize().Width)
                        X += 1;
                    break;

                case Direction.S:
                    if (Y - 1 >= 0)
                        Y -= 1;
                    break;

                case Direction.W:
                    if (X - 1 >= 0)
                        X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction:G}";
        }
    }
}
