﻿using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Auth;
using Application.DTOs.Auth;
using Application.DTOs.User;
using FluentValidation;
using MediatR;

namespace Application.Features.Auth.LogIn;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
{
    private readonly IAuth _auth;
    private readonly IUserRepository _userRepository;
    
    public LoginUserCommandHandler(IAuth auth, IUserRepository userRepository)
    {
        _auth = auth;
        _userRepository = userRepository;
    }
    
    public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new LoginUserCommandValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var user = await _auth.Login(request.AuthRequest);
        return user;
    }
}