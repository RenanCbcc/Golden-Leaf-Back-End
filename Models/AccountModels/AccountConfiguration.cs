using Golden_Leaf_Back_End.Models.ClerkModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Golden_Leaf_Back_End.Models.AccountModels
{
    public class AccountConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(a => a.Photo)
                .HasDefaultValue("iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAYAAADDPmHLAAAABHNCSVQICAgIfAhkiA" +
                "AAAAlwSFlzAAADdgAAA3YBfdWCzAAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAvpS" +
                "URBVHic7Z1tjFbFFcd/ZwGzsmAtClWhtEqBtrahVpSEKo2VWGO6Qglq46ZJP/ChxqaJppqotA1JKbGNL4ka" +
                "qDZtjUpQjOUlaSTBRGnUKLTVtFrBYtWibq0gvvASgT39MMO6uy48Z55778w8D/eX3GwCc+/9zznnmbl37sw" +
                "ZUVXaFRHpAM4GpgCnAaf6vwMPgDeHHG/5v9uBv6hqX1zl8ZB2CwAR6QTmAvOAS4EJBS/5NrAOWAtsVNX9Ba" +
                "+XFW0RACJyItANzAe+DXRVdKs9wAZgDbBeVXdXdJ9otHQAiEgXcA1wHXBC5Nu/D/wauE1V90S+d2m0ZACIy" +
                "EhgEfBz4JTEcnqBJcBvVfVgYi3BtFwAiMhCYCkwLbWWIWwDblLVh1MLCaFlAkBEJgEPArNTa2nAU8AVqroj" +
                "tRALLREAIjIL9+CVurm30gvMV9VnUgtpREdqAY0QkR7gcVrH+eC0Pu61Z022ASAiHSKyDLgf6Eytpwk6gft" +
                "FZJkfkMqSLLsA/3q3EjeQUwY7gD8BrwBv4Eb5Dv8FNyI4ccDfM4BLgEkl3X8dcGWOr4vZBYD/tfyR4s5/Hj" +
                "d6t1ZV/9qklq/jRhTnATMK6lkHfDe7YWVVzeoAlgFa4FgNTK9A13R/7SLalqW27yfqlVrAECP3FDDuE8Cs" +
                "CBpn+Xs1q7MntZ2zDABv2H1NGPRVoDuB3m5/71C9+2IEqvXI4hnAD/JsJvxVbxOwUFX/V76qxojIeOBhYE7" +
                "gqb3AOZrBYFEurycPEu78u4G5qZwP4O8912sJ4RRcndOTugkCFhLWhB4Ark6te5h6XO21hdRlYWrdSbsA/1" +
                "XvBcI+7PxIVe+qSFIhRORq4M6AU7YBZ2rCr4ipu4BFhDn/7lydD+C1hXQH03A2SEayFsCP9v0Le9+/CdfnH" +
                "6hOVXFEZBSwEfuDYS/wBU00SpiyBbgGu/Nfw/WXWTsfwGtciNNs4RScLZKQpAXwc/hewz6N61JVXV+hpNIR" +
                "kW7c8K+F94HPaYI5hqlagG7szt/Uas4H8Jo3GYufgLNJdFIFwPyAstdXpqJ6QrSH2KQ0oncBft7+O9imbj+" +
                "sqpdVLKlSRGQ17pmgEXuAkzXyuoMULcBc7PP2F1cpJBLWOnThbBOVFAEwz1jueVXdWqmSCPg6PG8sbrVNaU" +
                "QNAD/ZwzrRY22VWiJjrculsaePxW4Bzsa+Vu9YDIAJOBtFI3YATDGW26FNTuPKEV8X66dfq41KIXYAnNa4C" +
                "OAmcLYb1jpZbVQKsQPgVGO5VypVkQZrnaw2KoVcW4A3KlWRBmud2roFsFbuzcZFWg5rneoAoG4BopFrANQ" +
                "tQCRiB8CoyPdrRaLaKHYAWL93R/0VRMJap6hzAmIHwHvGchMrVZEGa52sNiqFugWIR90CAO8ayx3LLYDVR" +
                "qUQOwBeMJY7o1IVabDW6cVKVQwhdgD8zVjukkpVpMFap6gfwWIHgLVyk3xyhrbA18WabaStA2ArsNdYNvr" +
                "smAqx1mUvzkbRiBoAqnoIl0fPwrEYAE95G0UjxZzAR4zlZojI9EqVRMDXwZpfyGqb0kgRAGtwS6Mt/KJKI" +
                "ZGw1kFxtolK9ABQ1beAp43FF/osoS2J125ZEwDwtLdNVFKtDFoVUPZXlamonhDtITYpjVSLQ7uA14FxxlPa" +
                "fXHoLmByiiXiSVoAX9GQRA93+IRMLYHXekfAKXelyg+QMkHEeNwS8eONp7Rrgoh9uKXhSZJdJUsQ4Su8IuC" +
                "UOYTl30nFnYSljVuRyvmQOFewiHwKeImwFHHtlCSqF/iiqkadAzCQpEmifMWvDTztdm/orPCabg887dqUzg" +
                "fS5wn0LdBGwlOu/gYYlYH2UV5LqP6NqbVr6jyBhxGRKcAW4MTAU1s1VexuYKaqbi9fVRip8wQC4A3RA4Tm0" +
                "p8DbPbv3FHx99xMuPP7cBnDkzsfyKMLGNCc3kT7p4u/KbWdB9UntYAhxhXgoQLGVfLeMOIh/JtXLkcWzwAD" +
                "8QMpqyk+HyC3LWPWApdpZgNZ2QUA9AfBKmBBSZdMvWnUI8D3cnM+ZBoA0J9JfCXQ0mnicK3ZlZrpvsJZvA" +
                "UMhzfYFcDPCH87yIE+nPYrcnU+ZNwCDERELgYewP75ODW7cK96j6YW0ohsW4AhbABuSC0igBtwmrMn6xZA" +
                "RMYBPwB+CExNqyaYl3FfO/+gqrtSizkSWQaAn0t3Fe4ZoBX3DR7IftwGUcs1w93EswoAEZmL2zl0ZmotFbE" +
                "FuEFVN6YWcpgsAkBEvoqbQHlxai2ReBS4XlX/nlpI6qHficDvgEMUG2JtxeOQr/vEY24oWESOx334uRb7n" +
                "MB2ZR9wK7BUVffFvnmKDSNm4Eb4vlzhbRQ3/LsNt9hyK7Adl3zhgyEHwNghx6dxOXun+2MablhYKtT8Im7" +
                "E0JpavhSiBYCICO4X/0vguJIvfxD3gPWYP55RVesqZBMiMhr3KfhCf8wERpZ5D+Aj4EbgVo3lmIh9fTPTvo" +
                "527AbuAb4DjE3w/DLW3/ser6XMum0k0rNBDEMtAHaWZJgDwHrgcqAzttOPUsdOr2k94fsHH+nYCSxo6QCg2" +
                "Ayfocb4KTA+tbMNdR7vtZYV9JXOIKrKCCOA5SVUvhe4DhiT2rFN2GCM195bgh2WAyNaIgBwr3VrClZ4J/Bj" +
                "MmrmC9ij09elaIuwBjg+6wAATgKeLFDJPuD3uP3zkjuvZNuc7OvWV8A+TwInZRkAwGTcMq9mK/cP4PzUjo" +
                "oQCOf7ujZrp5dwS8nzCQAf3VsLVOpmYGRq50QMgpG+zs3aa2tZrWQZlekCnm2yIvtwM2eSOyVRIPR4GzRju" +
                "2eBrqQBgFsXt6HJCrwJnJvaCakP4Fxvi2ZsuIGC6yOLCBfcPL1mhG8m8VewnA7cSOnmJm35AAUWmxQR3Wwf" +
                "tpIKXmda/cC9Pq9s0qY3Rw0AoLsJkX3AjakNnfuB+xjUzKtidzP3C/4aKCKfBZ4jbIr2HtzDXjvtB1wZIjI" +
                "P17R3BZy2C/iaqv4n5F5B08L9ap1VhDlfqZ0fhLdVD852VsYBq7yPzISuC1gKzA48Z3Ht/HC8zRYHnjYb56" +
                "OgG1n7prmE900rU/eprX4Q/mDYh0unV94zgIgchxu+DFmcsQWYownmubUTfv7kJsKmyr8MfEVVP2pU0NoF/" +
                "IQw578FzK+dXxxvw/k4m1qZivNZQxq2ACIyGfgnMNp48/3AN1X1WWP5GgMici4uNY11pdRe4Euq+vrRClla" +
                "gNuwOx9gUe388vE2XRRwymic7xpe+GgPIBcRaUSqPswPhaEjsBc1/RAoIpuxP3y8gBuIyDYZQjvg3/OfA84" +
                "0nrJFVc850n8esQvwCzWtzlfgqtr51eNtfBX2QaKZ3pfDcrRngJCEDPeq6p8DytcUwNv63oBTjujLYbsA/8" +
                "RpXcu+C5eX750AQTUFEZHDs7Csw/Kzhns4P1ILEPLrX1I7Pz7e5ksCThnWp59oAURkGm7ioWUh5H+Bz6vq/" +
                "gAhNSUhIp3Aq8BnDMUVtzfBtoH/OFwL8H3sq2BvqZ2fDm/7W4zFBefbwf84TAvwCnC64YK7cHvdfGgUUFMB" +
                "IjIGt/eS5Vng36o6aBv7QS2AiHwDm/MBbq+dnx7vA+tOJad7H/cztAvoMV7oIGEbPtVUywqcTywM8nF/APg" +
                "EzZcbL/KoJtzpqmYw3hfWrKSXe18Dg1uAC3Fr+yzcZyxXEw+rT07C+RoYHADfMl7gPexbotbEYx3ONxb6fT" +
                "0wAC4wnry6fvXLD++T1cbi/b7ugP4NHM8ynlxP8MwXq2/O8j7vbwHOx2X1aMRB3KyUmjx5AtvbwAicz/sDw" +
                "Nr8b1HVDxoXq0mB980WY/EL4OMAOM940mOhomqiY/XRefBxAEwv+eI16bD6aDq4DwTjgbcNJyguW1epGThr" +
                "ysVnNP0Q2we9CR3Y5/vvqJ2fP95HO4zFp4YEwLbGRWoyweqrqR24TNgWtjYppiY+Vl9N68ClRS/zojXpsfp" +
                "qSgf2SYV5bHdeY8Hqq3EduLTnFt5tUkxNfKy+GtuBS2psoR4BbB2svhoT0gLUAdA6WH01tg6A9iQoAOouo" +
                "P0wdwH/B2qZxNsHYgUVAAAAAElFTkSuQmCC");
        }
    }
}
