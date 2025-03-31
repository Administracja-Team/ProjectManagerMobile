using ProjectManagerMobile.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Services
{
    public class TokenStorageService
    {
        private const string AccessTokenKey = "AccessToken";
        private const string RefreshTokenKey = "RefreshToken";
        private const string TokenExpiryDateTimeKey = "TokenExpiryDateTime";

        public TokenStorageService()
        {
            
        }

        public async Task<bool> ShouldRefreshTokens()
        {
            string? dateTimeString = await GetTokenExpiryDateTimeAsync();
            if (DateTime.TryParse(dateTimeString, out DateTime dateTime))
            {
                if (DateTime.Now >= dateTime)
                    return true;
            }

            return false;
        }

        public async Task<bool> IsUserLoggedIn()
        {
            if (await GetAccessTokenAsync() == null ||
                await GetRefreshTokenAsync() == null ||
                await GetTokenExpiryDateTimeAsync() == null) { return false; }

            return true;
        }

        public async Task SaveUserSession(BearerTokenDto tokenDto)
        {
            await SaveAccessTokenAsync(tokenDto.AccessToken);
            await SaveRefreshTokenAsync(tokenDto.RefreshToken);
            await SaveTokenExpiryDateAsync(tokenDto.ExpiresAt);
        }

        public async Task SaveAccessTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(AccessTokenKey, token);
        }

        public async Task SaveRefreshTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(RefreshTokenKey, token);
        }

        public async Task SaveTokenExpiryDateAsync(DateTime dateTime)
        {
            await SecureStorage.Default.SetAsync(TokenExpiryDateTimeKey, dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public async Task<string?> GetBearerTokenAsync()
        {
            return "Bearer " + await SecureStorage.Default.GetAsync(AccessTokenKey);
        }

        public async Task<string?> GetAccessTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(AccessTokenKey);
        }

        public async Task<string?> GetRefreshTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(RefreshTokenKey);
        }

        public async Task<string?> GetTokenExpiryDateTimeAsync()
        {
            return await SecureStorage.Default.GetAsync(TokenExpiryDateTimeKey);
        }

        public void RemoveUserSessionAsync()
        {
            SecureStorage.Default.Remove(AccessTokenKey);
            SecureStorage.Default.Remove(RefreshTokenKey);
            SecureStorage.Default.Remove(TokenExpiryDateTimeKey);
        }

    }
}
