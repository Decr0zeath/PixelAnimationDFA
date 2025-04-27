
namespace PixelAnimationStateMachine
{
    public interface IStateMachine
    {
        State CurrentState { get; }
        void ApplyInput(Input input);
    }
}