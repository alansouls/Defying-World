using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour
{
    const float barWidth = 200;
    const float maxHealth = 100;
    const float maxMana = 50;

    public PlayerBehaviour player;
    public GameObject healthGO;
    public GameObject manaGO;
    private RectTransform health;
    private RectTransform mana;
    // Start is called before the first frame update
    void Start()
    {
        health = healthGO.GetComponent<RectTransform>();
        mana = manaGO.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var newHealthWidth = (player.life / maxHealth) * barWidth;
        var newHealthX = -(barWidth - newHealthWidth) / 2;
        var newManaWidth = (player.mana / maxMana) * barWidth;
        var newManaX = -(barWidth - newManaWidth) / 2;

        health.sizeDelta = new Vector2(newHealthWidth, health.sizeDelta.y);
        health.localPosition = new Vector3(newHealthX, health.localPosition.y, 0);
        mana.sizeDelta = new Vector2(newManaWidth, mana.sizeDelta.y);
        mana.localPosition = new Vector3(newManaX, mana.localPosition.y, 0);
    }
}
