using System.Threading;
using Character.Controllers;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using Utils.AddressableLoader;
using Utils.DataAPI;

public struct CharacterDataByStyleName
{
    public string styleName;
}

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
        //ICharacterData characterData = new CharacterDataDummy();

        var getCharacterDataQueryByStyleName = @"query CharacterDataByStyleName($styleName: String!) {
          CharacterDataByStyleName(styleName: $styleName) {
            styleName
            moveSpeed
            jumpForce
          }
        }";

        var characterDataByStyleNameVariables = new CharacterDataByStyleName()
        {
            styleName = "basePlayer"
        };

        var fullQueryCharacterData = new GraphQlQuery()
        {
            query = getCharacterDataQueryByStyleName,
            variables = characterDataByStyleNameVariables
        };

        var characterData = await GraphqlUtils.GetModel<CharacterData>(fullQueryCharacterData, 
            "CharacterDataByStyleName", 
            gameToken.Token);
        
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
