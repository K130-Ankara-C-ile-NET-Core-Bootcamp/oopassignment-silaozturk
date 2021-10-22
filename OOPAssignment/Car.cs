using System;
using System.Linq;

namespace OOPAssignment
{
    public class Car : ICarCommand, IObservable<CarInfo>
    {
        public Guid Id { get; }
        public Coordinates Coordinates;
        public Direction Direction;
        public ISurface Surface;

        private IObserver<CarInfo> Observer { get; set; }

        private readonly Direction[]  directions = new Direction[] { Direction.N, Direction.E, Direction.S, Direction.W };

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Id = Guid.NewGuid();
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        public void Attach(IObserver<CarInfo> observer)
        {
            observer.Update(new CarInfo(Id, Coordinates));
            Observer = observer;
        }

        public void Move()
        {
            long nextX = Coordinates.X;
            long nextY = Coordinates.Y;

            switch (Direction)
            {
                case Direction.N:
                    nextY++;
                    break;
                case Direction.E:
                    nextX++;
                    break;
                case Direction.S:
                    nextY--;
                    break;
                case Direction.W:
                    nextX--;
                    break;
            }

            var newCoordinates = new Coordinates(nextX, nextY);
            if (!Surface.IsCoordinatesInBounds(newCoordinates))
                throw new System.Exception("Harita dışına çıktınız!");

            if (Observer.GetObservables().Any(x => x.Coordinates.X == newCoordinates.X && x.Coordinates.Y == newCoordinates.Y))
                throw new Exception("Önündeki araba ile çarpıştı!");

            Coordinates = newCoordinates;
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }

        public void TurnLeft()
        {
            var directionIndex = Array.IndexOf(directions, Direction);

            if (--directionIndex < 0)
                directionIndex = 3;

            Direction = directions[directionIndex];
        }

        public void TurnRight()
        {
            var directionIndex = Array.IndexOf(directions, Direction);

            if (++directionIndex > 4)
                directionIndex = 0;

            Direction = directions[directionIndex];
        }
    }
}