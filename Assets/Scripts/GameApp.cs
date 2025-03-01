using Character;
using Character.Controllers;
using Character.Models;
using Character.Views;
using UnityEngine;

public class GameApp : IGameApp
{
    public void StartApp()
    {
        ICharacterView characterView = GameObject.Find("CharacterBase").GetComponent<CharacterView>();
        ICharacterData characterData = new CharacterData();
        
        ICharacterBaseController characterBaseController = new CharacterBaseController(characterView, characterData);
        characterBaseController.StarCharacter();
    }
}
