using OtusProject.WeaponComponents;

namespace OtusProject.PlayerInput
{
    public sealed class AttackController
    {
        private FireWeaponComponent _fireComponent;
        private ReloadWeaponComponent _reloadComponent;
        private InputManager _inputManager;
        AttackController(FireWeaponComponent fireComponent, ReloadWeaponComponent reloadComponent, InputManager inputManager)
        {
            _fireComponent = fireComponent;
            _reloadComponent = reloadComponent;
            _inputManager = inputManager;
            _inputManager.OnFire += AttackRequest;
        }

        private void AttackRequest()
        {
            if (!_fireComponent.TryAttack(out var ammo))
            {
                if (ammo == 0)
                {
                    _reloadComponent.ReloadRequest();
                }
            }
        }
    }
}

