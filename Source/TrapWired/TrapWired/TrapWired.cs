using RimWorld;
using Verse;

namespace TrapWired
{
    public class TrapWiredComp :ThingComp
    {
        private bool wickStarted = false;
        public override void CompTick()
        {
            base.CompTick();
            //// 전력이 연결된 상태인지 확인
            CompPowerTrader powerComp = base.parent.GetComp<CompPowerTrader>();
            CompExplosive explosiveComp = base.parent.GetComp<CompExplosive>();
            if (explosiveComp == null || powerComp == null) return;
            if (powerComp.PowerOn == false) return;
            if (explosiveComp.wickStarted) return;
            if (wickStarted) return;
            // 전력이 연결된 상태면 폭발 실행
            //GenExplosion.DoExplosion(parent.Position, parent.Map, 3.0f, DamageDefOf.Bomb, parent);
            explosiveComp.StartWick();
            wickStarted = true;
        }
    }
    public class TrapWiredCompProperties : CompProperties
    {
        public TrapWiredCompProperties()
        {

            this.compClass = typeof(TrapWiredComp);
        }
        public TrapWiredCompProperties(Type compClass):base(compClass) {

            this.compClass = compClass;
        }
    }
}
