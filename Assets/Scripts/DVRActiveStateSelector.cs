using UnityEngine;
using Oculus.Interaction;
using UnityEngine.Events;

public class DVRActiveStateSelector : ActiveStateSelector
{
  [SerializeField] private ActiveStateSelector _vrActiveStateSelector;
  [SerializeField] private SimpleActiveState _desktopActiveStateSelector;

  public new event UnityAction WhenSelected;
  public new event UnityAction WhenUnselected;


  //   private void OnEnable()
  //   {
  //     // _vrActiveStateSelector.WhenSelected += OnSelect;
  //     _desktopActiveStateSelector.WhenSelected += OnSelect;
  //   }

  //   private void OnDisable()
  //   {

  //     // _vrActiveStateSelector.WhenSelected -= OnSelect;
  //     _desktopActiveStateSelector.WhenSelected -= OnSelect;
  //   }

  //   private void OnSelect()
  //   {
  //     WhenSelected?.Invoke();
  //   }

  //   private void OnUnselect()
  //   {
  //     WhenUnselected?.Invoke();
  //   }
}
