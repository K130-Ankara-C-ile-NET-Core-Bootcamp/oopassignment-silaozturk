using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment
{
    public class Surface : ISurface, ICollidableSurface, IObserver<CarInfo>
    {
        private readonly long width;
        private readonly long height;
        public long Width => width;
        public long Height => height;
        private readonly List<CarInfo> ObservableCars;

        public Surface(long width, long height)
        {
            this.width = width;
            this.height = height;
            ObservableCars = new List<CarInfo>();

        }

        public List<CarInfo> GetObservables()
        {
            return new List<CarInfo>(ObservableCars);
        }

        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            if (coordinates.Y > Height || coordinates.Y < 0|| coordinates.X > Width || coordinates.X < 0)
                return false;

            return true;
        }


        public void Update(CarInfo provider)
        {
            var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
            if (car != null)
                car = provider;
            else
                ObservableCars.Add(provider);
        }
    }
}