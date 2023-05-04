using MHR.StateMachine;

namespace Enemy
{
    public abstract class EnemyState : State
    {
        public Enemy Enemy => _enemy;
    
        private Enemy _enemy;

        public void SetEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }
    
        public abstract override void EnterState();

        public abstract override void ExitState();

        public abstract override void ProcessState();

        public abstract override void ProcessStateFixed();
    }
}