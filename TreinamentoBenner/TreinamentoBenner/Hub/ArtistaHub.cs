using System.Collections.Concurrent;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoBenner.Controllers;
using TreinamentoBenner.Core.Context;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Hub
{
    public class ArtistaHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly TreinamentoBennerContext _db = new TreinamentoBennerContext();
        public static readonly ConcurrentDictionary<string, int> Locks = new ConcurrentDictionary<string, int>();
        private static readonly object Lock = new object();

        public override async Task OnConnected()
        {
            var artistas = _db.Artistas.OrderBy(q => q.Nome);
            await Clients.Caller.all(artistas);
            await Clients.Caller.allLocks(Locks.Values);
        }

        public override async Task OnReconnected()
        {
            await OnConnected();
        }

        public async Task OnDisconnected()
        {
            int removed;
            if (Locks.TryRemove(Context.ConnectionId, out removed))
            {
                await Clients.All.allLocks(Locks.Values);
            }
        }

        public void TakeLook(Artista artista)
        {
            lock (Lock)
            {
                if (Locks.Values.Any(id => artista.Id == id))
                    return;

                Locks.AddOrUpdate(Context.ConnectionId, artista.Id, (key, oldValue) => artista.Id);
                Clients.Caller.takeLookSuccess(artista);
                Clients.All.allLocks(Locks.Values);
            }
        }

        public void Add(Artista artista)
        {
            if (artista == null) return;

            _db.Artistas.Add(artista);
            _db.SaveChanges();

            Clients.All.add(artista);
        }

        public void Delete(Artista artista)
        {
            _db.Artistas.Remove(_db.Artistas.Find(artista.Id));
            _db.SaveChanges();

            Clients.All.delete(artista);
        }

        public void Update(Artista artista)
        {
            if (artista != null)
            {
                _db.Artistas.AddOrUpdate(artista);
                _db.SaveChanges();

                Clients.All.update(artista);
            }
            int removed;
            Locks.TryRemove(Context.ConnectionId, out removed);
            Clients.All.allLocks(Locks.Values);
        }
    }
}