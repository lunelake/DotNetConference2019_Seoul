using System;
using System.Collections.Generic;
using System.Text;

namespace NetConference2019
{
    public class Resource : IDisposable
    {
        public void CopyFrom(Resource resource)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class UsingStatement
    {
        public static void Demo()
        {
            using (var src = new Resource())
            {
                using (var dest = new Resource())
                {
                    dest.CopyFrom(src);
                }
            }
        }
    }
}
