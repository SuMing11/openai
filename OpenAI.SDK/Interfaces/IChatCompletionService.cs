﻿using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI.GPT3.Interfaces;

/// <summary>
///     Given a chat conversation, the model will return a chat completion response.
/// </summary>
public interface IChatCompletionService
{
    /// <summary>
    ///     Creates a completion for the chat message
    /// </summary>
    /// <param name="modelId">ID of the model to use. Currently, only gpt-3.5-turbo and gpt-3.5-turbo-0301 are supported.</param>
    /// <param name="chatCompletionCreate"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<ChatCompletionCreateResponse> CreateCompletion(ChatCompletionCreateRequest chatCompletionCreate, string? modelId = null, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters and returns a stream of CompletionCreateRequests
    /// </summary>
    /// <param name="modelId">The ID of the model to use for this request</param>
    /// <param name="chatCompletionCreate"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    IAsyncEnumerable<ChatCompletionCreateResponse> CreateCompletionAsStream(ChatCompletionCreateRequest chatCompletionCreate, string? modelId = null, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters
    /// </summary>
    /// <param name="createCompletionModel"></param>
    /// <param name="modelId">The ID of the model to use for this request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<ChatCompletionCreateResponse> Create(ChatCompletionCreateRequest chatCompletionCreate, Models.Model modelId, CancellationToken cancellationToken = default)
    {
        return CreateCompletion(chatCompletionCreate, modelId.EnumToString(), cancellationToken);
    }
}