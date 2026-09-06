using UnityEngine;

namespace GUI.Screens
{
  public abstract class Screen : MonoBehaviour
  {
    public abstract void Open();
    public abstract void Close();
  }
}