using System.Threading;
using Character.Models;
using Cysharp.Threading.Tasks;

namespace Character.Controllers
{
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView characterView;
        private ICharacterData characterData;
        private CancellationTokenRegistration cancellationTokenRegistration;
        
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData, CancellationToken gameToken)
        {
            this.characterView = characterView;
            this.characterData = characterData;
            cancellationTokenRegistration = gameToken.Register(Dispose);
            
            MovementCycleTask(gameToken).Forget();
        }

        private async UniTask MovementCycleTask(CancellationToken gameToken)
        {
            while (!gameToken.IsCancellationRequested)
            {
                await UniTask.NextFrame();
            }
        }

        public void Dispose()
        {
            cancellationTokenRegistration.Dispose();
        }
    }
}