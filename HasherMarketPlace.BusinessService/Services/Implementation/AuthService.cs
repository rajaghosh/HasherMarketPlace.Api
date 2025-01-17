﻿using Microsoft.IdentityModel.Tokens;
using HasherMarketPlace.BusinessService.Services.Interface;
using HasherMarketPlace.ModelHelper.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HasherMarketPlace.BusinessService.Services.Implementation
{
    public class AuthService : IAuthService
    {
        //private readonly IConfiguration _config;
        private readonly IAppSettings _appSettings;
        private readonly byte[] key;
        private readonly string _jwt_key;
        private readonly string _jwt_id;
        private readonly string _jwt_secret;
        private readonly string _jwt_audience;
        private readonly string _jwt_issuer;

        //public AuthService(IMovieTicketRepository<UserMaster> repo, IConfiguration config)
        public AuthService(IAppSettings appSettings)
        {
            //_repo = repo;
            //_config = config;

            //_jwt_key = _config.GetValue<string>("Jwt:jwt_key") ?? "";
            //_jwt_id = _config.GetValue<string>("Jwt:jwt_id") ?? "";
            //_jwt_secret = _config.GetValue<string>("Jwt:jwt_secret") ?? "";
            //_jwt_audience = _config.GetValue<string>("Jwt:jwt_audience") ?? "";
            //_jwt_issuer = _config.GetValue<string>("Jwt:jwt_issuer") ?? "";
            //key = Encoding.ASCII.GetBytes(_jwt_key);

            _appSettings = appSettings;
            _jwt_key = _appSettings._jwt_key;
            _jwt_id = _appSettings._jwt_id;
            _jwt_secret = _appSettings._jwt_secret;
            _jwt_audience = _appSettings._jwt_audience;
            _jwt_issuer = _appSettings._jwt_issuer;
            key = Encoding.ASCII.GetBytes(_jwt_key);
        }

        public async Task<string> GenerateJwtToken(string email, string userRole)
        {
            TokenModel model = new TokenModel()
            {
                Token_Id = _jwt_id,
                Token_Secret = _jwt_secret,
                UserEmail = email
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                List<Claim> claimList = new List<Claim>();
                claimList.Add(new Claim("id", model.Token_Id.ToString()));
                claimList.Add(new Claim("secret", model.Token_Secret.ToString()));
                claimList.Add(new Claim("user", model.UserEmail.ToString()));
                claimList.Add(new Claim("role", userRole));
                //new Claim(ClaimTypes.Role, user.Role)

                var sub = new ClaimsIdentity(claimList);
                var exp = DateTime.UtcNow.AddDays(1);
                var signCred = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = sub,
                    Audience = _jwt_audience,
                    Issuer = _jwt_issuer,
                    Expires = exp,
                    SigningCredentials = signCred
                };

                SecurityToken token = await Task.Run(() =>
                {
                    return tokenHandler.CreateToken(tokenDescriptor);
                });

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                await Task.Delay(0);

                var tokenValidationParam = new TokenValidationParameters();

                tokenValidationParam.ValidateIssuerSigningKey = true;
                tokenValidationParam.IssuerSigningKey = new SymmetricSecurityKey(key);
                tokenValidationParam.ValidateIssuer = true;
                tokenValidationParam.ValidateAudience = true;
                tokenValidationParam.ValidIssuer = _jwt_issuer;
                tokenValidationParam.ValidAudience = _jwt_audience;
                tokenValidationParam.ClockSkew = TimeSpan.Zero; //token expires exactly at token expiration time

                tokenHandler.ValidateToken(token, tokenValidationParam, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var id = jwtToken.Claims.First(x => x.Type == "id").Value;
                var secret = jwtToken.Claims.First(x => x.Type == "secret").Value;

                var jwtId = _jwt_id;
                var jwtSecret = _jwt_secret;

                if (id == jwtId && secret == jwtSecret)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
