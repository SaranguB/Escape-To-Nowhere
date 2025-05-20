using Main;
using UnityEngine;

namespace VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void ConfigureVFX(VFXType vfxType, Vector3 position)
            => vfxView.ConfigureVFX(vfxType, position);

        public void OnParticleEffectCompleted()
            => GameService.Instance.vfxService.ReturnVFXToPool(this);
    }
}