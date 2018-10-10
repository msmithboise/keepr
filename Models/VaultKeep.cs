using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeep
    {

        // it's own ID
        public int Id { get; set; }
        public int KeepId { get; set; }
        public int VaultId { get; set; }

        public string UserId { get; set; }

        public VaultKeep(int keepId, int vaultId, string userId)
        {

            KeepId = keepId;
            VaultId = vaultId;
            UserId = userId;

        }




    }





}