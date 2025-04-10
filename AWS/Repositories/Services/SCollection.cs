
using AWS.DTO;
using AWS.DTO.ArtworkDTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace AWS.Repositories.Services
{
    public class SCollection : ICollection
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SCollection(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<List<LikeCollection>> GetAllCollection()
        {

            try
            {
                var a = await this.cxt.LikeCollections.ToListAsync();
                return a;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LikeCollection>> GetAllCollectionByUserId(string userId)
        {
            try
            {
                var a = await this.cxt.LikeCollections.Where(x => x.UserId.Equals(userId)).ToListAsync();
                return a;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LikeCollection> GetCollectionByUserId(string userId)
        {
            try
            {
                var a = await this.cxt.LikeCollections.Where(x => x.UserId.Equals(userId)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LikeCollection> Love(CollectionDTO collection)
        {
            try
            {
                var add = new LikeCollection();
                add.ArtworkId = collection.ArtworkId;
                add.UserId = collection.UserId;
                add.Time = collection.TIme;

                cxt.LikeCollections.Add(add);

                // count +1
                var like = await cxt.Artworks
                   .FirstOrDefaultAsync(a => a.ArtworkId == collection.ArtworkId);

                if (like != null)
                {
                    like.LikeTimes = (like.LikeTimes ?? 0) + 1;
                    cxt.Entry(like).State = EntityState.Modified;
                }

                await cxt.SaveChangesAsync();

                return add;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public async Task<bool> UnLove(DeleteCollectionDTO id)
        {
        try
        {
            if (id != null)
            {
                var obj =  this.cxt.LikeCollections.Where(x =>
                x.ArtworkId.Equals(id.ArtworkId) &&
                x.UserId.Equals(id.UserId)).FirstOrDefault();

                this.cxt.LikeCollections.Remove(obj);

                    // count - 1
                    var like = await cxt.Artworks
                       .FirstOrDefaultAsync(a => a.ArtworkId == id.ArtworkId);

                    if (like != null)
                    {
                        like.LikeTimes = (like.LikeTimes ?? 0) - 1;
                        cxt.Entry(like).State = EntityState.Modified;
                    }
                    
                    await this.cxt.SaveChangesAsync();

                return true;
            }
            return false;
        }
        catch (Exception ex)
        {

            throw new Exception($"{ex.Message}");
        }
    }

    
    }
}
