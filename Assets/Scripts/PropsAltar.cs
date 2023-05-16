using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{
    public class PropsAltar : MonoBehaviour
    {
        public Player player;
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        [SerializeField] private ParticleSystem moneyIncomeParticle;
        private bool isMakingMoney;

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            
            isMakingMoney = true;
            moneyIncomeParticle.Play();
            StartCoroutine(GetMoney());
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
            
            moneyIncomeParticle.Stop();
            isMakingMoney = false;
        }

        IEnumerator GetMoney()
        {
            while (isMakingMoney)
            {
                player.moneyCount += 2;
                player.moneyText.text = player.moneyCount.ToString();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
    }
}