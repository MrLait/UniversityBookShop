﻿using Microsoft.Extensions.Options;
using IdentityServer.Application.Common.Options;
using Client.HttpClients.IdentityServerApi;
using Identity.Domain.Models;
using Identity.Application.Common.Models.Requests;
using Client.HttpClients.IdentityApi;
using IdentityModel.Client;

namespace Client
{
    public class AuthenticationServiceTest
    {
        private readonly IdentityServerClient _identityServerClient;
        private readonly UserClient _userClient;
        private readonly IdentityServerApiOptions _identityServerOptions;

        public AuthenticationServiceTest(
            IdentityServerClient identityServerClient,
            UserClient userClient,
            IOptions<IdentityServerApiOptions> options)
        {
            _identityServerClient = identityServerClient;
            _userClient = userClient;
            _identityServerOptions = options.Value;
        }

        public async Task<string> RunUsersClientTests(string[] args)
        {
            var token = await _identityServerClient.GetApiToken(_identityServerOptions);
            _userClient.HttpClient.SetBearerToken(token.AccessToken);

            var userName = "xyz7";
            var roleName = "ShopClient";
            var roleNames = new[] { "ShopClient", "ShopClient3" };

            var addResult = await _userClient.Add(new CreateUserRequest() { User = new ApplicationUser() { UserName = userName }, Password = "Password_1" });
            Console.WriteLine($"ADD: {addResult.Succeeded}");

            //Thread.Sleep(100);

            //var changePasswordRequest = await _usersClient.ChangePassword(new UserPasswordChangeRequest() { UserName = userName, CurrentPassword = "Password_1", NewPassword = "Password_2" });
            //Console.WriteLine($"CHANGE PASSWORD: {changePasswordRequest.Succeeded}");

            //Thread.Sleep(100);

            //var getOneRequest = await _usersClient.Get(userName);
            //Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            //Thread.Sleep(100);

            //var userToUpdate = getOneRequest.Payload;
            //userToUpdate.DefaultAddress = new Address()
            //{
            //    City = "Warsaw",
            //    Country = "Poland",
            //    PostalCode = "00-001",
            //    AddressLine1 = "Jasna 21",
            //    AddressLine2 = "34"
            //};
            //var updateResult = await _usersClient.Update(userToUpdate);
            //Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

            //Thread.Sleep(100);

            //var addToRoleRequest = await _usersClient.AddToRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            //Console.WriteLine($"ADD TO ROLE: {addToRoleRequest.Succeeded}");

            //Thread.Sleep(100);

            //var removeFromRoleRequest = await _usersClient.RemoveFromRole(new AddRemoveRoleRequest() { UserName = userName, RoleName = roleName });
            //Console.WriteLine($"REMOVE FROM ROLE: {removeFromRoleRequest.Succeeded}");

            //Thread.Sleep(100);

            //var addToRolesRequest = await _usersClient.AddToRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            //Console.WriteLine($"ADD TO MANY ROLES: {addToRolesRequest.Succeeded}");

            //Thread.Sleep(100);

            //var removeFromRolesRequest = await _usersClient.RemoveFromRoles(new AddRemoveRolesRequest() { UserName = userName, RoleNames = roleNames });
            //Console.WriteLine($"REMOVE FROM MANY ROLES: {removeFromRolesRequest.Succeeded}");

            //getOneRequest = await _usersClient.Get(userName);
            //Console.WriteLine($"GET ONE: {getOneRequest.Code}");

            //Thread.Sleep(100);

            //var deleteResult = await _usersClient.Remove(getOneRequest.Payload);
            //Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

            //Thread.Sleep(100);

            //var getAllRequest = await _usersClient.GetAll();
            //Console.WriteLine($"GET ALL: {getOneRequest.Code}");

            //Thread.Sleep(100);

            return "OK";
        }

        //public async Task<string> RunRolesClientTests(string[] args)
        //{
        //    var token = await _identityServerClient.GetApiToken(_identityServerOptions);
        //    _rolesClient.HttpClient.SetBearerToken(token.AccessToken);

        //    var roleName = "xyz7";

        //    var addResult = await _rolesClient.Add(new IdentityRole(roleName));
        //    Console.WriteLine($"ADD: {addResult.Succeeded}");

        //    Thread.Sleep(100);

        //    var getOneRequest = await _rolesClient.Get(roleName);
        //    Console.WriteLine($"GET ONE: {getOneRequest.Code}");

        //    Thread.Sleep(100);

        //    var userToUpdate = getOneRequest.Payload;
        //    var updateResult = await _rolesClient.Update(userToUpdate);
        //    Console.WriteLine($"UPDATE: {updateResult.Succeeded}");

        //    Thread.Sleep(100);

        //    getOneRequest = await _rolesClient.Get(roleName);
        //    Console.WriteLine($"GET ONE: {getOneRequest.Code}");

        //    Thread.Sleep(100);

        //    var deleteResult = await _rolesClient.Remove(getOneRequest.Payload);
        //    Console.WriteLine($"DELETE: {deleteResult.Succeeded}");

        //    Thread.Sleep(100);

        //    var getAllRequest = await _rolesClient.GetAll();
        //    Console.WriteLine($"GET ALL: {getOneRequest.Code}");

        //    Thread.Sleep(100);

        //    return "OK";
        //}
    }
}