using System.Threading;
using Character.Controllers;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using Utils.AddressableLoader;

public class GameApp : IGameApp
{
    private CancellationTokenSource gameToken;

    public GameApp()
    {
        gameToken = new CancellationTokenSource();
    }
    
    public async UniTaskVoid StartApp()
    {
        var characterView = await AddressableLoader.InstantiateAsync<ICharacterView>("basePlayer");
        ICharacterData characterData = new CharacterDataDummy();
        
        ICharacterBaseController characterBaseController =
            new CharacterBaseController(characterView, characterData, gameToken.Token);
    }

    public void Dispose()
    {
        gameToken.Cancel();
        gameToken?.Dispose();
        gameToken = null;
    }
}
